﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaAccesoDatos
{
    public class datUsuario
    {
        #region singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion

        #region Metodos
        public List<entUsuario> ListarUsuario()
        {
            SqlCommand cmd = null;
            List<entUsuario> lista = new List<entUsuario>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarUsuario", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    entUsuario U = new entUsuario();
                    U.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    U.nomUsuario = dr["nomUsuario"].ToString();
                    U.correo = dr["correo"].ToString();
                    U.correo = dr["correo"].ToString();
                    U.estUsuario = Convert.ToBoolean(dr["estUsuario"]);
                    U.fecCreacion = Convert.ToDateTime(dr["fecCreacion"]);
                    U.tipo = Convert.ToBoolean(dr["tipo"]);

                    entCliente C = new entCliente();
                    C.idCliente = Convert.ToInt16(dr["idCliente"]);
                    C.nombreCliente = dr["Nombres"].ToString();
                    C.apellidoCliente = dr["Apellidos"].ToString();
                    C.DNI = dr["DNI"].ToString();
                    C.telefono = Convert.ToInt16(dr["Telefono"]);
                    C.estCliente = Convert.ToBoolean(dr["EstCliente"]);

                    U.idCliente = C;
                    lista.Add(U);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return lista;
        }

        public entUsuario VerificarAcceso(String Usuario, String Password)
        {
            SqlCommand cmd = null;
            entUsuario u = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsuario", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new entUsuario();
                    u.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                    u.fecCreacion = Convert.ToDateTime(dr["FecCreacion"]);
                    u.nomUsuario = dr["nomUsuario"].ToString();
                    u.correo = dr["correo"].ToString();
                    u.estUsuario = Convert.ToBoolean(dr["estUsuario"]);
                    u.tipo = Convert.ToBoolean(dr["tipo"]);

                    entCliente C = new entCliente();
                    C.idCliente= Convert.ToInt32(dr["idCliente"]);
                    C.nombreCliente = dr["NombreCliente"].ToString();
                    C.apellidoCliente = dr["ApellidoCliente"].ToString();
                    C.DNI = dr["Dni"].ToString();
                    C.telefono = Convert.ToInt32(dr["Telefono"]);
                    C.estCliente = Convert.ToBoolean(dr["EstCliente"]);
                    u.idCliente = C;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return u;
        }
        #endregion
    }
}
