using Microsoft.AspNetCore.Authorization;

namespace ConfArchWeb.Authorization
{
    public class ProposalRequirement : IAuthorizationRequirement
    {
        public ProposalRequirement(bool mustbeApproved)
        {
            MustBeApproved = mustbeApproved;
        }
        public bool MustBeApproved { get; set; }
    }
}
