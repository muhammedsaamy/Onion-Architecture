using AutoMapper;
using MediatR;
using PostLand.Application.Contracts;
using PostLand.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostLand.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommend>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public UpdatePostCommandHandler(IPostRepository postRepository, IMapper mapper)
        {
            this._postRepository = postRepository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePostCommend request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);
            await _postRepository.UpdateAsync(post);

            return Unit.Value;
        }
    }
}
