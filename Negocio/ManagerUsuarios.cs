using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class ManagerUsuarios
    {
        private SqlConnection conn;

        public SqlConnection Conn
        {
            get => conn;
            set => conn = value;
        }
        public ManagerUsuarios()
        {
            Conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=academia;Integrated Security=true;");
        }

        public List<Usuario> GetAll()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            Usuario usuarioActual;

            SqlCommand cmdGetUsuarios = new SqlCommand("SELECT * FROM usuarios", Conn);

            Conn.Open();

            SqlDataReader rdrUsuarios = cmdGetUsuarios.ExecuteReader();

            while (rdrUsuarios.Read())
            {
                usuarioActual = new Usuario
                {
                    ID = (int)rdrUsuarios["id"],
                    TipoDoc = (Nullable<int>)rdrUsuarios["tipo_doc"],
                    NroDoc = (Nullable<int>)rdrUsuarios["nro_doc"],
                    FechaNac = rdrUsuarios["fecha_nac"].ToString(),
                    Apellido = rdrUsuarios["apellido"].ToString(),
                    Nombre = rdrUsuarios["nombre"].ToString(),
                    Direccion = rdrUsuarios["direccion"].ToString(),
                    Telefono = rdrUsuarios["telefono"].ToString(),
                    Email = rdrUsuarios["email"].ToString(),
                    Celular = rdrUsuarios["celular"].ToString(),
                    NombreUsuario = rdrUsuarios["usuario"].ToString(),
                    Clave = rdrUsuarios["clave"].ToString(),
                };

                listaUsuarios.Add(usuarioActual);
            }

            Conn.Close();

            return listaUsuarios;
        }

        public void BorrarUsuario(Usuario usuarioActual)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM usuarios WHERE id=@id");
            cmd.Parameters.Add(new SqlParameter("@id", usuarioActual.ID.ToString()));

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        public void ActualizarUsuario(Usuario usuarioActual)
        {
            SqlCommand cmd = new SqlCommand(
                "UPDATE usuarios " +
                "SET tipo_doc = @tipodoc, nro_doc = @nro_doc, fecha_nac = @fecha_nac, " +
                "apellido = @apellido, nombre = @nombre, direccion = @direccion, " +
                "telefono = @telefono, email = @email, celular = @celular, " +
                "usuario = @usuario, clave = @clave " +
                "WHERE id = @id", Conn);
            cmd.Parameters.Add(new SqlParameter("@tipo_doc", usuarioActual.TipoDoc.ToString()));
            cmd.Parameters.Add(new SqlParameter("@nro_doc", usuarioActual.NroDoc.ToString()));
            cmd.Parameters.Add(new SqlParameter("@fecha_nac", usuarioActual.FechaNac));
            cmd.Parameters.Add(new SqlParameter("@apellido", usuarioActual.Apellido));
            cmd.Parameters.Add(new SqlParameter("@nombre", usuarioActual.Nombre));
            cmd.Parameters.Add(new SqlParameter("@direccion", usuarioActual.Direccion));
            cmd.Parameters.Add(new SqlParameter("@telefono", usuarioActual.Telefono));
            cmd.Parameters.Add(new SqlParameter("@email", usuarioActual.Email));
            cmd.Parameters.Add(new SqlParameter("@celular", usuarioActual.Celular));
            cmd.Parameters.Add(new SqlParameter("@usuario", usuarioActual.Nombre));
            cmd.Parameters.Add(new SqlParameter("@clave", usuarioActual.Clave));

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }

        public void AgregarUsuario(Usuario usuarioActual)
        {
            SqlCommand cmd = new SqlCommand(
                "INSERT INTO " +
                "usuarios(tipo_doc, nro_doc, fecha_nac, apellido, nombre, " +
                "direccion, telefono, email, celular, usuario, clave) " +
                "VALLUES " +
                "(@tipo_doc, @nro_doc, @fecha_nac, @apellido, @nombre, " +
                "@direccion, @telefono, @email, @celular, @usuario, @clave)", Conn);
            cmd.Parameters.Add(new SqlParameter("@tipo_doc", usuarioActual.TipoDoc.ToString()));
            cmd.Parameters.Add(new SqlParameter("@nro_doc", usuarioActual.NroDoc.ToString()));
            cmd.Parameters.Add(new SqlParameter("@fecha_nac", usuarioActual.FechaNac));
            cmd.Parameters.Add(new SqlParameter("@apellido", usuarioActual.Apellido));
            cmd.Parameters.Add(new SqlParameter("@nombre", usuarioActual.Nombre));
            cmd.Parameters.Add(new SqlParameter("@direccion", usuarioActual.Direccion));
            cmd.Parameters.Add(new SqlParameter("@telefono", usuarioActual.Telefono));
            cmd.Parameters.Add(new SqlParameter("@email", usuarioActual.Email));
            cmd.Parameters.Add(new SqlParameter("@celular", usuarioActual.Celular));
            cmd.Parameters.Add(new SqlParameter("@usuario", usuarioActual.NombreUsuario));
            cmd.Parameters.Add(new SqlParameter("@clave", usuarioActual.Clave));

            Conn.Open();

            cmd.ExecuteNonQuery();

            Conn.Close();
        }
    }

    public class Usuario
    {
        private int id;
        private Nullable<int> tipoDoc;
        private Nullable<int> nroDoc;
        private string fechaNac;
        private string apellido;
        private string nombre;
        private string direccion;
        private string telefono;
        private string email;
        private string celular;
        private string usuario;
        private string clave;

        public int ID
        {
            get => id;
            set => id = value;
        }
        public Nullable<int> TipoDoc
        {
            get => tipoDoc;
            set => tipoDoc = value;
        }
        public Nullable<int> NroDoc
        {
            get => nroDoc;
            set => nroDoc = value;
        }
        public string FechaNac
        {
            get => fechaNac;
            set => fechaNac = value;
        }
        public string Apellido
        {
            get => apellido;
            set => apellido = value;
        }
        public string Nombre
        {
            get => nombre;
            set => nombre = value;
        }
        public string Direccion
        {
            get => direccion;
            set => direccion = value;
        }
        public string Telefono
        {
            get => telefono;
            set => telefono = value;
        }
        public string Email
        {
            get => email;
            set => email = value;
        }
        public string Celular
        {
            get => celular;
            set => celular = value;
        }
        public string NombreUsuario
        {
            get => usuario;
            set => usuario = value;
        }
        public string Clave
        {
            get => clave;
            set => clave = value;
        }

    }
}
