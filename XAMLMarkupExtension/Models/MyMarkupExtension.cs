using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace XAMLMarkupExtension.Models
{
    public class MyMarkupExtension : MarkupExtension
    {
        public MyMarkupExtension()
        {
                
        }

        public string FirstStr { get; set; }
        public string SecondStr { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return FirstStr + " " + SecondStr;   
        }
    }
}
