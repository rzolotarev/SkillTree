using Contracts.Nodes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.GraphProvider.Contracts
{
    public interface IGraphProvider
    {
        void Unlock(SkillNode skillNode);
    }
}
