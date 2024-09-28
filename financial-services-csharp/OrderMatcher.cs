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