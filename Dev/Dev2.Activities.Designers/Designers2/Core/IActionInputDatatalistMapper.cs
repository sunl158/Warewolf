using System.Collections.Generic;
using Dev2.Common.Interfaces.DB;

namespace Dev2.Activities.Designers2.Core
{
    public interface IActionInputDatatalistMapper
    {
        void MappInputsToDatalist(IEnumerable<IServiceInput> inputs);
    }
}