using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace GST.Application.Commands.Features.CalculateTotalSum
{
    public class CalculateTotalSumCommandHandler : IRequestHandler<CalculcateTotalSumCommand, double>
    {
        private readonly IFruitAndVegetablesDataUnitOfWork _data;

        public CalculateTotalSumCommandHandler(IFruitAndVegetablesDataUnitOfWork data)
        {
            _data = data;
        }

        public async Task<double> Handle(CalculcateTotalSumCommand request, CancellationToken cancellationToken)
        {
            // TODO


            return 0;
        }
    }
}
