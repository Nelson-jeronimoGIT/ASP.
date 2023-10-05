using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;

namespace Modelo
{
    public class Empleado{
        ConexionBD conectar;
        private DataTable drop_puesto(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("select id_Puesto as id_Puesto,puesto from puestos;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }
        private DataTable grid_empleados(){
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("select e.id_Empleados as id,e.codigo,e.nombres,e.apellidos,e.dirección,e.telefono,e.fecha_nacimiento,p.puesto,e.id_Puesto");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public void grid_empleados(System.Web.UI.WebControls.GridView grid_empleados)
        {
            throw new NotImplementedException();
        }

        public void grid_empleados(System.Web.UI.WebControls.GridView grid_empleados)
        {
            throw new NotImplementedException();
        }

        public void drop_puesto(DropDownList drop){
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppenDataBoundItems = true;
            drop.Items.Add("<< Elig Puesto >>");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_puesto();
            drop.DataTextField = "puesto";
            drop.DataValueField = "id";
            drop.DataBind();
        }
        public void grid_empleados(GridView grid){
            grid.DataSource = grid_empleados();
            grid.DataBind();
        }
        public int crear(string codigo, string nombre, string apellidos, string direccion, string telefono, string fecha,int id_puesto){
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("INSERT INTO empleados(codigo,nombres,apellidos,direccion,telefono,fecha_nacimiento VALUES ('{0}','{1}','{2}','{3}','{4}','{5}',{6});",codigo,nombre,apellidos,direccion,telefono,fecha,id_puesto )");
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;

        }
        public int actualizar(int id,string codigo, string nombre, string apellidos, string direccion, string telefono, string fecha, int id_puesto)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("UPDATE empleados set codigo='{0}',nombres='{1}',apellidos='{2}',direccion='{3}',telefono='{4}',fecha_nacimiento='{5}',id_puesto={6} where id_empleado ={7};", codigo, nombre, apellidos, direccion, telefono, fecha, id_puesto,id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }
        public int borrar(int id)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("DELETE from empleados where id_empleado ={0};",id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }

    }
}
