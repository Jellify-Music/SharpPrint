using System.Text;
using SharpPrint.lib;

namespace SharpPrint.Algorithm;

public class ChromaPrinter(AlgorithmFactory factory, long scanDuration, float sampleRate)
{
    private long _ptr { get; } = Essentia.AlgorithmCreateChromaPrinter(factory._ptr, scanDuration, sampleRate);

    public string Scan(MonoLoader loader)
    {
        StringBuilder sb = new StringBuilder(8096);
        Essentia.ChromaPrinterScan(loader._ptr, _ptr, sb, sb.Capacity);

        return sb.ToString();
    }
}