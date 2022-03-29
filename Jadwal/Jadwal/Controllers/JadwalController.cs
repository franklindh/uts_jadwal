using Jadwal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mapel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JadwalController : ControllerBase
    {
        private JadwalContext _context;

        public JadwalController(JadwalContext context)
        {
            this._context = context;
        }

        //Get : api/mapel
        [HttpGet]
        public ActionResult<IEnumerable<JadwalItem>> GetMapelItems()
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetAllJadwal();
        }

        //Get :api/mapel{id} / 
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<IEnumerable<JadwalItem>> GetJadwalItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwal(id);
        }

        //Post
        [HttpPost]
        public ActionResult<JadwalItem> AddJadwal([FromForm] string tahun_akademik, [FromForm] string semester, [FromForm] int id_guru, [FromForm] string hari, [FromForm] int id_kelas, [FromForm] int id_mapel, [FromForm] string jam_mulai, [FromForm] string jam_selesai)
        {
            JadwalItem ji = new JadwalItem();
            ji.tahun_akademik = tahun_akademik;
            ji.semester = semester;
            ji.id_guru = id_guru;
            ji.hari = hari;
            ji.id_kelas = id_kelas;
            ji.id_mapel = id_mapel;
            ji.jam_mulai = jam_mulai;
            ji.jam_selesai = jam_selesai;

            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.AddJadwal(ji);
        }

        [HttpOptions("{id}", Name = "Get")]
        //Get :api/mapel{id} / dari id_mapel
        public ActionResult<IEnumerable<JadwalItem>> OptGetJadwalItem(String id)
        {
            _context = HttpContext.RequestServices.GetService(typeof(JadwalContext)) as JadwalContext;
            return _context.GetJadwal1(id);
        }
    }
}
