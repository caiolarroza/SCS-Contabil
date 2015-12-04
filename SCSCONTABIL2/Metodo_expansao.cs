using System;

namespace Xceed.Wpf.Toolkit
{
    public static class Methods
    {
        public static string semFormato(this MaskedTextBox _mask)
        {
            //metodo de extensão que retira a formatação do conteudo para adicionar no BD
            
            String retString = _mask.Text.Replace(".", "").Replace("/", "").Replace(",", "").Replace("-", "").Replace("_", "");
            
            return retString;
        }
    }
}


