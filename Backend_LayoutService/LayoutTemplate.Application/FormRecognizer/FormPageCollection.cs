using Azure.AI.FormRecognizer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LayoutTemplate.Application.FormRecognizer
{
    /// <summary>
    /// A read-only collection of <see cref="FormPage"/> objects.
    /// </summary>
    public class FormPageCollection : ReadOnlyCollection<FormPage>
    {
        /// <inheritdoc/>
        internal FormPageCollection(IList<FormPage> list) : base(list)
        {
        }
    }
}