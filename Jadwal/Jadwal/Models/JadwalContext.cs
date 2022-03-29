using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;


namespace Jadwal.Models
{
    public class JadwalContext : DbContext
    {
        public JadwalContext(DbContextOptions<JadwalContext> options) : base(options)
        {
        }
        public string ConnectionString { get; set; }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection("Server = localhost; Database = sibaru; Uid = root; Pwd = ");
        }

        public List<JadwalItem> GetAllJadwal()
        {
            List<JadwalItem> list = new List<JadwalItem>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from jadwal_guru", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }
        public List<JadwalItem> GetJadwal(string id)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT id_jadwal_guru, tahun_akademik, g.id_guru, hari, id_kelas, id_mapel, jam_mulai, jam_selesai FROM jadwal_guru, guru g WHERE nip = @id)" , conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("g.id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }

        public List<JadwalItem> GetJadwal1(string id)
        {
            List<JadwalItem> list = new List<JadwalItem>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM jadwal_guru WHERE id_mapel = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new JadwalItem()
                        {
                            id = reader.GetInt32("id_jadwal_guru"),
                            tahun_akademik = reader.GetString("tahun_akademik"),
                            semester = reader.GetString("semester"),
                            id_guru = reader.GetInt32("id_guru"),
                            hari = reader.GetString("hari"),
                            id_kelas = reader.GetInt32("id_kelas"),
                            id_mapel = reader.GetInt32("id_mapel"),
                            jam_mulai = reader.GetString("jam_mulai"),
                            jam_selesai = reader.GetString("jam_selesai")
                        });
                    }
                }
            }
            return list;
        }
        public JadwalItem AddJadwal(JadwalItem ji)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("insert into jadwal_guru (tahun_akademik, semester, id_guru, hari, id_kelas, id_mapel, jam_mulai, jam_selesai) values (@tahun_akademik, @semester, @id_guru, @hari, @id_kelas, @id_mapel, @jam_mulai, @jam_selesai)", conn);
                cmd.Parameters.AddWithValue("@tahun_akademik", ji.tahun_akademik);
                cmd.Parameters.AddWithValue("@semester", ji.semester);
                cmd.Parameters.AddWithValue("@id_guru", ji.id_guru);
                cmd.Parameters.AddWithValue("@hari", ji.hari);
                cmd.Parameters.AddWithValue("@id_kelas", ji.id_kelas);
                cmd.Parameters.AddWithValue("@id_mapel", ji.id_mapel);
                cmd.Parameters.AddWithValue("@jam_mulai", ji.jam_mulai);
                cmd.Parameters.AddWithValue("@jam_selesai", ji.jam_selesai);
                cmd.ExecuteReader();

            }
            return ji;
        }
    }
}
