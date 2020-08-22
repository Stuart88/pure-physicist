using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurePhysicist.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurePhysicist.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        #region Private Fields

        private readonly IItemRepository ItemRepository;

        #endregion Private Fields

        #region Public Constructors

        public ItemController(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        #endregion Public Constructors

        #region Public Methods

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Item> Create([FromBody] Item item)
        {
            ItemRepository.Add(item);
            return CreatedAtAction(nameof(GetItem), new { item.Id }, item);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(string id)
        {
            Item item = ItemRepository.Remove(id);

            if (item == null)
                return NotFound();

            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Edit([FromBody] Item item)
        {
            try
            {
                ItemRepository.Update(item);
            }
            catch (Exception)
            {
                return BadRequest("Error while editing item");
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Item> GetItem(string id)
        {
            Item item = ItemRepository.Get(id);

            if (item == null)
                return NotFound();

            return item;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Item>> List()
        {
            return ItemRepository.GetAll().ToList();
        }

        #endregion Public Methods
    }
}