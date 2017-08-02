using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ConfArchShared.Models;


namespace ConfArchWeb.Authorization
{
    public class ProposalApprovedAuthorizationHandler : AuthorizationHandler<ProposalRequirement, ProposalModel>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ProposalRequirement requirement, ProposalModel resource)
        {
            if (!requirement.MustBeApproved)
                if (resource.Approved)
                    context.Fail();

            if (requirement.MustBeApproved)
                if (!resource.Approved)
                    context.Fail();

            return Task.CompletedTask;
        }
    }
}
