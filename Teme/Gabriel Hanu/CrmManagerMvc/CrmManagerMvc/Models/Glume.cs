using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrmManagerMvc.Models
{
    public class Glume
    {
        public Glume()
        {
            GenereazaGlumaZilei();
        }
        List<string> listaGlume = new List<string>(new string[] {
            "Chuck Norris poate apasa Ctrl-Alt-Delete cu un singur deget",
            "Majoritatea oamenilor cred ca dinozaurii T-Rex nu pot aplauda pentru ca au bratele scurte. Adevarul este ca nu pot pentru ca au murit toti.",
            "Un caine de la antidrog a fost invatat cum miroase spaga, apoi a muscat toata sectia de politie.",
            "M-a interogat odata politia, dar nu am avut emotii deloc. Nevasta-mea imi pune intrebari mult mai grele.",
            "Chuck Norris şi-a luat extra-opţiunea 1500 minute în reţea şi le-a terminat de vorbit într-o oră."});
        public string GlumaZilei { get; set; }
        public void GenereazaGlumaZilei()
        {
            GlumaZilei = listaGlume[new Random().Next(0, listaGlume.Count)];
        }
    }
}