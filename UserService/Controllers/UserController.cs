using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        // GET: api/<UserController>
        [HttpGet]
        public ActionResult Get()
        {
            UserHandler handler = new UserHandler();
            IEnumerable<UserDTO> userlist = handler.GetAllUsers();
            if (userlist.Count() != 0)
            {
                return Ok(userlist);
            }
            return NotFound("There are no students found");
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            UserHandler handler = new UserHandler();
            UserDTO returnUser = handler.GetUser(id);
            if (returnUser != null)
            {
                return Ok(returnUser);
            }
            return NotFound($"User could not be found: There is no User with id : {id}");
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult Post(UserDTO user)
        {
            if (user.Id == 0)
            {
                UserHandler handler = new UserHandler();
                handler.CreateUser(user);
                return Ok("User created succesfully");
            }
            return BadRequest($"User could not be created: Id was expected to be 0 but was {user.Id}");
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public ActionResult Put(UserDTO user)
        {
            UserHandler handler = new UserHandler();
            if (handler.GetUser(user.Id) != null)
            {
                handler.UpdateUser(user);
                return Ok("User updated succesfully");
            }
            return BadRequest($"User could not be updated: There is no user with id {user.Id}");

        }

        // DELETE api/<UserController>/5
        [HttpDelete]
        public ActionResult Delete(UserDTO user)
        {
            UserHandler handler = new UserHandler();
            if (handler.GetUser(user.Id) != null)
            {
                handler.DeleteUser(user);
                return Ok("User Deleted succesfully");
            }
            return BadRequest($"User could not be deleted: There is no user with id {user.Id}");
        }
    }
}
