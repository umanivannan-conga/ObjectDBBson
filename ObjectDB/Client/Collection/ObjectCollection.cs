using System.Diagnostics;

namespace ObjectDB
{
    public class ObjectCollection<T>
    {
        public ObjectCollection()
        {

        }

        public void Insert(List<T> entities)
        {
            var mapper = new BsonMapper();
            var watch = new Stopwatch();
            watch.Start();
            watch.Stop();
            
            var docs = entities.Select(e => mapper.ToDocument(e));
            List<byte[]> binDocs = new List<byte[]>();
            foreach (var doc in docs)
            {
                var bDoc = BsonSerializer.Serialize(doc);
                binDocs.Add(bDoc);
                
            }
            watch.Restart();
            foreach (var binDoc in binDocs)
            {
                var ser = BsonSerializer.Deserialize(binDoc);
            }
            watch.Stop();
            watch.Restart();
            foreach (var binDoc in binDocs)
            {
                var ser = BsonSerializer.Deserialize(binDoc);
            }
            watch.Stop();

            long microseconds = watch.ElapsedTicks / (Stopwatch.Frequency / (1000L * 1000L));

            //Console.WriteLine(microseconds);
            

        }
    }
}
