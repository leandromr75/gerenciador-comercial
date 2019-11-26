using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciador_Comercial
{
    public static class GerenciadorDeFormulario
    {
        static readonly List<Form> formularios = new List<Form>();
        ///<sumary>
        ///Método responsável por gerenciar a visibilidade dos formulários
        ///</sumary>
        ///<param name="formulario"></param>
        public static void Abre(Form formulario)
        {
            SetaVisibilidadeDosFormularios();
            for (int i = 0; i < formularios.Count; i++)
            {
                if (formulario.Name == formularios[i].Name)
                {
                    formularios[i].Show();
                    return;
                }
            }
            formularios.Add(formulario);
            formulario.Show();
        }
        /// <summary>
        /// método responsável por fechar a instancia do objeto do tipo form
        /// </summary>
        /// <param name="formulario"></param>
        public static void Fecha(Form formulario)
        {
            if (formularios.Contains(formulario))
            {
                for (int i = 0; i < formularios.Count; i++)
                {
                    if (formulario.Name == formularios[i].Name)
                    {
                        formularios[i].Dispose();
                        formularios.Remove(formulario);
                        return;
                    }
                }
            }
        }

        private static void SetaVisibilidadeDosFormularios()
        {
            for (int i = 0; i < formularios.Count; i++)
            {
                formularios[i].Visible = false;
            }
        }
    }
}
