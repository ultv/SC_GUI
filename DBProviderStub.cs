using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;

namespace CS_GUI
{
    public class DBProviderStub : IDBProvider
    {
        public Player GetPlayerById(int id)
        {
            var player = new Fixture().Build<Player>()
                                        .With(p => p.Name, "Александр")
                                        .With(p => p.TotalVic, 0)
                                        .With(p => p.CurVic, 0)
                                        .With(p => p.Brains, null)
                                        .Create();

            return player;

        }
    }
}
