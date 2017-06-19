using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace Medicine
{
  public class Disease
  {
    private int _id;
    private string _name;
    private string _symtoms;
    private string _image;
    private int _category_id;

    public Disease(string name, string symtoms, string image, int category_id, int id = 0)
    {
      _name = name;
      _symtoms = symtoms;
      _image = image;
      _category_id = category_id;
      _id = id;
    }

    public int GetId()
    {
      return _id;
    }
    public int GetCategoryId()
    {
      return _category_id;
    }
    public string GetName()
    {
      return _name;
    }
    public string GetSymtoms()
    {
      return _symtoms;
    }
    public string GetImage()
    {
      return _image;
    }

    public override bool Equals(System.Object otherDisease)
    {
      if(!(otherDisease is Disease))
      {
        return false;
      }
      else
      {
        Disease newDisease = (Disease) otherDisease;
        bool idEquality = (this.GetId() == newDisease.GetId());
        bool nameEquality = (this.GetName() == newDisease.GetName());
        bool symtomsEquality = (this.GetSymtoms() == newDisease.GetSymtoms());
        bool imageEquality = (this.GetImage() == newDisease.GetImage());
        bool category_idEquality = (this.GetCategoryId() == newDisease.GetCategoryId());
        return (idEquality && nameEquality && imageEquality && symtomsEquality && category_idEquality);
      }
    }

    public static List<Disease> GetAll()
    {
      List<Disease> AllDisease = new List<Disease>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM diseases;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);
        string symtoms = rdr.GetString(2);
        string image = rdr.GetString(3);
        int category_id = rdr.GetInt32(4);
        Disease newDisease = new Disease(name, symtoms, image, category_id, id);
        AllDisease.Add(newDisease);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllDisease;
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("INSERT INTO diseases (name, symtoms, image, category_id) OUTPUT INSERTED.id VALUES (@name,  @symtoms, @image, @category_id);", conn);

      SqlParameter namePara = new SqlParameter("@name", this.GetName());
      SqlParameter symtomsPara = new SqlParameter("@symtoms", this.GetSymtoms());
      SqlParameter imagePara = new SqlParameter("@image", this.GetImage());
      SqlParameter categoryIdPara = new SqlParameter("@category_id", this.GetCategoryId());

      cmd.Parameters.Add(namePara);
      cmd.Parameters.Add(symtomsPara);
      cmd.Parameters.Add(imagePara);
      cmd.Parameters.Add(categoryIdPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

    public static Disease Find(int id)
    {
      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM diseases WHERE id = @id;", conn);
      SqlParameter IdPara = new SqlParameter("@id", id.ToString());

      cmd.Parameters.Add(IdPara);
      SqlDataReader rdr = cmd.ExecuteReader();

      int foundid = 0;
      string name = null;
      string symtoms = null;
      string image = null;
      int category_id = 0;

      while(rdr.Read())
      {
        foundid = rdr.GetInt32(0);
        name = rdr.GetString(1);
        symtoms = rdr.GetString(2);
        image = rdr.GetString(3);
        category_id = rdr.GetInt32(4);
      }
      Disease foundDisease = new Disease(name, symtoms, image, category_id, foundid);
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
     return foundDisease;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM diseases; DELETE FROM categories_diseases; DELETE FROM diseases_remedies;", conn);
      cmd.ExecuteNonQuery();
      conn.Close();
    }
  }
}
