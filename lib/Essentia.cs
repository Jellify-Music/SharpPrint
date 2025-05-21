using System.Runtime.InteropServices;
using System.Text;

namespace SharpPrint.lib;

public static class Essentia
{
    [DllImport("libessentia_bindings")]
    public static extern void init();
    
    [DllImport("libessentia_bindings")]
    public static extern void destroy();
    [DllImport("libessentia_bindings")]
    internal static extern long createAlgorithmFactoryInstance();
    
    [DllImport("libessentia_bindings")]
    internal static extern long AlgorithmCreateMonoLoader(long factory, string file, float sampleRate);
    
    [DllImport("libessentia_bindings")]
    internal static extern long AlgorithmCreateChromaPrinter(long factory, float scanDuration, float sampleRate);
    
    [DllImport("libessentia_bindings")]
    internal static extern void ChromaPrinterScan(long loader, long chromaPrinter, StringBuilder str, int length);
    
    [DllImport("libessentia_bindings")]
    public static extern void TestChroma();
}