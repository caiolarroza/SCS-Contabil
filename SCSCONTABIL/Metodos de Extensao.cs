using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
    {
        public static class Methods
        {
            public static string semFormato(this MaskedTextBox _mask)
            {
                //metodo de extensão que retira a formatação do conteudo para adicionar no BD
                _mask.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                String retString = _mask.Text;
                _mask.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
                return retString;
            }
        }
    }


