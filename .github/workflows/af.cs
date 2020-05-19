using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for Audio_stegno
/// </summary>
public class Audio_stegno
{
	public Audio_stegno()
	{
		//
		// TODO: Add constructor logic here
		//



	}
    public void Encrypt(string fname, string msg, string fname1)
    {
        msg = msg.PadLeft(200, ' ');
        FileStream fs = new FileStream(fname, FileMode.Open);
        FileStream ds = new FileStream(fname1, FileMode.Create);
        byte[] b = new byte[fs.Length];
        fs.Read(b, 0, (int)fs.Length);
        byte[] ms = System.Text.Encoding.ASCII.GetBytes(msg);
        int cn = b.Length - 1;
        for (int j = 0; j < 200; j++)
        {
            b[cn - j] = ms[j];
        }
        ds.Write(b, 0, b.Length);
        ds.Close();
        fs.Close();
    }

    public string Decrypt(string fname)
    {
        FileStream fs = new FileStream(fname, FileMode.Open);
        byte[] b = new byte[fs.Length];
        fs.Read(b, 0, (int)fs.Length);
        int cn = b.Length - 1;
        byte[] ms = new byte[200];
        for (int j = 0; j < 200; j++)
        {
            ms[j] = b[cn - j];
        }
        string mm = System.Text.Encoding.ASCII.GetString(ms);
        return mm;
    }

}
