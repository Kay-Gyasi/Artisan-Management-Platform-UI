using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AMP.Web.Models.Commands;
using AMP.Web.Models.Dtos;
using AMP.Web.Models.Services.HttpServices.Base;
using Kessewa.Extension.Shared.HttpServices.Models;

namespace AMP.Web.Models.Services.HttpServices;

[Service]
public class InvitationService
{
    private readonly IHttpRequestBase _http;

    public InvitationService(IHttpRequestBase http)
    {
        _http = http;
    }
    
    public async Task<RequestResponse> AddInvite(InvitationCommand command) 
        => await _http.PostRequestAsync("Invitation/AddInvite", command, new CancellationToken());
    
    public async Task<List<InvitationDto>> GetUserInvites()
        => await _http.GetRequestAsync<List<InvitationDto>>("Invitation/GetUserInvites", new CancellationToken());

}