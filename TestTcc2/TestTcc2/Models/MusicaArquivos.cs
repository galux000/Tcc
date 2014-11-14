using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Hosting;


namespace TestTcc2.Models
{
    public class MusicaArquivos
    {

        public List<Musica> listaMusica()
        {
            List<Musica> listaDeMusica = new List<Musica>();
            
            //DirectoryInfo dirInfo = new DirectoryInfo("~/mp3");
            DirectoryInfo dirInfo = new DirectoryInfo(HostingEnvironment.MapPath("/mp3/"));

            int i = 0;
            foreach (var item in dirInfo.GetFiles())
            {
                listaDeMusica.Add(new Musica()
                {

                    path = "/mp3/" + item.Name

                });
                i = i + 1;
            }
            return listaDeMusica;
        }

    }
}