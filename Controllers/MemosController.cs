using Microsoft.AspNetCore.Mvc;
using MemosBackend;



namespace MemosBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class MemosController : ControllerBase
    {
        //private static readonly Memo[] memos = new[]
        //static List<Memo> memos = new List<Memo>()
        //{
        //    new Memo{ Id=0, Text="memo1", CreatedOn=DateTime.Now.AddDays(0) },
        //    new Memo{ Id=1, Text="memo2", CreatedOn=DateTime.Now.AddDays(1) },
        //    new Memo{ Id=2, Text="memo3", CreatedOn=DateTime.Now.AddDays(2) },
        //    new Memo{ Id=3, Text="memo4", CreatedOn=DateTime.Now.AddDays(3) }
        //};
        private readonly MemosContext _context;
        public MemosController(MemosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Memo> Get()
        {
            return _context.Memos;
        }

        [HttpGet("{id}")]
        public ActionResult<Memo> Get(int id)
        {
            var memos = _context.Memos.ToList();
            var index = memos.FindIndex(ev => ev.Id == id);
            if (memos[index] != null)
            {
                return memos[index];
            }
            else
                return NotFound("Does Not Appear");
        }

        [HttpPost]
        public ActionResult Post([FromBody] Memo memo)
        {
            _context.Memos.Add(memo);
            return CreatedAtAction(nameof(Post), new { Id = memo.Id }, memo);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Memo memo)
        {
            var memos = _context.Memos.ToList();
            if (id != memo.Id)
                return BadRequest();
            else
            {
                var index = memos.FindIndex(ev => ev.Id == memo.Id);
                if (index == -1)
                    return BadRequest();
                else
                    memos[index] = memo;
                return Ok(StatusCode(204));
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var memos = _context.Memos.ToList();
            var index = memos.FindIndex(ev => ev.Id == id);
            if (index == -1)
                return NotFound();
            else
            {
                memos.Remove(memos[index]);
                return Ok();
            }
        }
    }
}
