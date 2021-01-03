﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication4
{
    public partial class test : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.pres.Style["background-color"] = "rgb(211,211,211) !important";
            if (Session["CIN"] != null)
            {

                Master.conx.Visible = false;
                Master.insc.Visible = false;
                Master.imgP.Visible = true;
                Master.profil.Visible = true;
                Master.profil.Text = "Bienvenue " + Session["NomEtd"];
                Master.Decx.Visible = true;
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ToString());
                //c.cmd = new SqlCommand("Select img from Etudiant where CIN='" + Session["CIN"] + "'", con);
                //con.Open();
                //c.dr = c.cmd.ExecuteReader();

                if (Session["img_Etd"] != null)
                {
                    Master.imgP.ImageUrl = "" + Session["img_Etd"];
                }
                else
                {
                    Master.imgP.ImageUrl = "~/imgProfil/ph.png";
                }
            }
            else
            {
                if (Session["Admin"] != null)
                {
                    Master.conx.Visible = false;
                    Master.insc.Visible = false;
                    Master.imgP.Visible = true;
                    Master.profil.Visible = true;
                    Master.profil.Text = "Bienvenue " + Session["Admin"];
                    Master.Decx.Visible = true;

                    c.cmd = new SqlCommand("Select img from Admine where Email='" + Session["Admin"] + "'", con);
                    con.Open();
                    c.dr = c.cmd.ExecuteReader();
                    if (c.dr.Read())
                    {
                        Master.imgP.ImageUrl = c.dr["img"].ToString();
                    }
                    else
                    {
                        Master.imgP.ImageUrl = "~/imgProfil/ph.png";
                    }
                }
                else
                    if (Session["Etablissement"] != null)
                {
                    string Nom = "Bienvenue " + Session["Etablissement"];
                    string[] Ns = Nom.Split('@');
                    Master.ADD.Visible = true;
                    Master.conx.Visible = false;
                    Master.insc.Visible = false;
                    Master.imgP.Visible = true;
                    Master.profil.Visible = true;
                    Master.profil.Text = Ns[0];
                    Master.dropE.Visible = true;
                    Master.dropAdm.Visible = false;
                    Master.Decx.Visible = true;

                    c.cmd = new SqlCommand("Select img,ID_Etab from Etablissement where Email= '" + Session["Etablissement"] + "'", con);
                    con.Open();
                    c.dr = c.cmd.ExecuteReader();
                    if (c.dr.Read())
                    {
                        Session["ID_E"] = c.dr["ID_Etab"].ToString();
                        Master.imgP.ImageUrl = c.dr["img"].ToString();
                    }
                    else
                    {
                        Master.imgP.ImageUrl = "~/imgProfil/ph.png";
                    }
                }
                else
                {
                    if (Session["ID_Prof"] != null)
                    {
                        Master.cor.Visible = true;
                        Master.Decx.Visible = true;
                        Master.conx.Visible = false;
                        Master.insc.Visible = false;
                        Master.imgP.Visible = true;
                        Master.profil.Visible = true;
                        Master.profil.Text = "Bienvenue " + Session["NomProf"];
                        Master.dropE.Visible = true;
                        Master.dropAdm.Visible = false;

                        c.cmd = new SqlCommand("Select img from formateur where ID_For= '" + Session["ID_Prof"] + "'", con);
                        con.Open();
                        c.dr = c.cmd.ExecuteReader();
                        if (c.dr.Read())
                        {
                            Master.imgP.ImageUrl = c.dr["img"].ToString();
                        }
                        else
                        {
                            Master.imgP.ImageUrl = "~/imgProfil/ph.png";
                        }
                    }
                }
            }

        }
    }
}