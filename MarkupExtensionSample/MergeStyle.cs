using System;
using System.Windows;
using System.Windows.Markup;

namespace MarkupExtensionSample
{
    [MarkupExtensionReturnType(typeof(Style))]
    public class MergeStyle : MarkupExtension
    {
        public Style BasedOn { get; set; }
        public Style MergeWith { get; set; }


        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return MergeWithStyle(BasedOn, MergeWith);
        }

        private static Style MergeWithStyle(Style style, Style mergeStyle)
        {
            if(mergeStyle.BasedOn != null)
                MergeWithStyle(style, mergeStyle.BasedOn);

            foreach(var setter in mergeStyle.Setters)
                style.Setters.Add(setter);

            foreach(var trigger in mergeStyle.Triggers)
                style.Triggers.Add(trigger);

            return style;
        }
    }
}
