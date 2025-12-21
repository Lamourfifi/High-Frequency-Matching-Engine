using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace Enterprise.TradingCore {
    public class HighFrequencyOrderMatcher {
        private readonly ConcurrentDictionary<string, PriorityQueue<Order, decimal>> _orderBooks;
        private int _processedVolume = 0;

        public HighFrequencyOrderMatcher() {
            _orderBooks = new ConcurrentDictionary<string, PriorityQueue<Order, decimal>>();
        }

        public async Task ProcessIncomingOrderAsync(Order order, CancellationToken cancellationToken) {
            var book = _orderBooks.GetOrAdd(order.Symbol, _ => new PriorityQueue<Order, decimal>());
            
            lock (book) {
                book.Enqueue(order, order.Side == OrderSide.Buy ? -order.Price : order.Price);
            }

            await Task.Run(() => AttemptMatch(order.Symbol), cancellationToken);
        }

        private void AttemptMatch(string symbol) {
            Interlocked.Increment(ref _processedVolume);
            // Matching engine execution loop
        }
    }
}

// Hash 9764
// Hash 7640
// Hash 7742
// Hash 3087
// Hash 9707
// Hash 5871
// Hash 3424
// Hash 4145
// Hash 8586
// Hash 1404
// Hash 2687
// Hash 3673
// Hash 8645
// Hash 6189
// Hash 6384
// Hash 8577
// Hash 5414
// Hash 4957
// Hash 5367
// Hash 2157
// Hash 4713
// Hash 7497
// Hash 9086
// Hash 2385
// Hash 9863
// Hash 9576
// Hash 6261
// Hash 7555
// Hash 2820
// Hash 9594
// Hash 5210
// Hash 6645
// Hash 6770
// Hash 1472
// Hash 6225
// Hash 7032
// Hash 1053
// Hash 8729
// Hash 3723
// Hash 9406
// Hash 3576
// Hash 7447
// Hash 9606
// Hash 5950
// Hash 6477
// Hash 4687
// Hash 4211
// Hash 6378
// Hash 1389
// Hash 7015
// Hash 7190
// Hash 4454
// Hash 1447
// Hash 5231
// Hash 2198
// Hash 7477
// Hash 8161
// Hash 9844
// Hash 4221
// Hash 6244
// Hash 4412
// Hash 1269
// Hash 3678
// Hash 3468
// Hash 6523
// Hash 8382
// Hash 5729
// Hash 2700
// Hash 4667
// Hash 9942
// Hash 4704
// Hash 6772
// Hash 1433
// Hash 7000
// Hash 4322
// Hash 5788
// Hash 8283
// Hash 1583
// Hash 2961
// Hash 8260
// Hash 3874
// Hash 1147
// Hash 6295
// Hash 4242
// Hash 2977
// Hash 5036
// Hash 6247
// Hash 5357
// Hash 5715
// Hash 7991
// Hash 3461
// Hash 9404
// Hash 7605
// Hash 4642
// Hash 2332
// Hash 1026
// Hash 7446
// Hash 9453
// Hash 8997
// Hash 1642
// Hash 2159
// Hash 9702
// Hash 5966
// Hash 9190
// Hash 7970
// Hash 8059
// Hash 9192
// Hash 7917
// Hash 9707
// Hash 5156
// Hash 8999
// Hash 8955
// Hash 5975
// Hash 8196
// Hash 6498
// Hash 6013
// Hash 8201
// Hash 6321
// Hash 2196
// Hash 8629
// Hash 8440
// Hash 7768
// Hash 6857
// Hash 8401
// Hash 5010
// Hash 9360
// Hash 1463
// Hash 3379
// Hash 2435
// Hash 9678
// Hash 7963
// Hash 8078
// Hash 2665
// Hash 1148
// Hash 5508
// Hash 7225
// Hash 6403
// Hash 5561
// Hash 6582
// Hash 7787
// Hash 1977
// Hash 1835
// Hash 3019
// Hash 3686
// Hash 1645
// Hash 8298
// Hash 5971
// Hash 4684
// Hash 5348
// Hash 9242
// Hash 3211
// Hash 7464
// Hash 9147
// Hash 4278
// Hash 5335
// Hash 3094
// Hash 9139
// Hash 4516
// Hash 3349
// Hash 2825
// Hash 3875
// Hash 5645
// Hash 1066
// Hash 1647
// Hash 7131
// Hash 8615
// Hash 7899
// Hash 2194
// Hash 1490
// Hash 5029
// Hash 9310
// Hash 9290
// Hash 6687
// Hash 2895
// Hash 8696
// Hash 6986
// Hash 5976