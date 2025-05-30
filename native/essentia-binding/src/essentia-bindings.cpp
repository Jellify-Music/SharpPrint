//
// Created by brys0 on 5/19/25.
//
#include <essentia/essentia.h>
#include <essentia/pool.h>
#include <essentia/algorithmfactory.h>

using namespace std;
using namespace essentia;
using namespace standard;

// Creates a basic instance of essentia, with a pool that will hold any given audio frames in memory
extern "C" void init()
{
    essentia::init();
    Pool pool;
}


// Cleanup essentia
extern "C" void destroy()
{
    shutdown();
}

extern "C" EssentiaFactory<Algorithm> * createAlgorithmFactoryInstance() {
    return &AlgorithmFactory::instance();
}

extern "C" Algorithm * AlgorithmCreateMonoLoader(EssentiaFactory<Algorithm>* factory, const char* file, float sampleRate) {
    AlgorithmFactory& realFactory = *factory;

   return realFactory.create(
        "MonoLoader",
        "filename",file,
        "sampleRate", sampleRate);
}

extern "C" Algorithm * AlgorithmCreateChromaPrinter(EssentiaFactory<Algorithm>* factory, float scanDuration, float sampleRate) {
    AlgorithmFactory& realFactory = *factory;

    return realFactory.create("Chromaprinter",
                                         "maxLength", scanDuration,
                                         "sampleRate", sampleRate);
}

extern "C" void ChromaPrinterScan(Algorithm *loader, Algorithm *chromaPrinter, char *str, int len) {
    vector<Real> audio;
    string chromaprint;

    loader->output("audio").set(audio);
    loader->compute();

    chromaPrinter->input("signal").set(audio);
    chromaPrinter->output("fingerprint").set(chromaprint);
    chromaPrinter->compute();

    strncpy(str, chromaprint.data(), len);
}


extern "C" void TestChroma() {
    Pool pool;
    Real sampleRate = 44100.0;
    Real chromaprintDuration = 30.0;
    AlgorithmFactory& factory = AlgorithmFactory::instance();

    Algorithm* audioLoader = factory.create(
        "MonoLoader",
        "filename","/home/brys0/Downloads/008 - NF - Paralyzed.flac",
        "sampleRate", sampleRate);

    Algorithm* chromaPrinter = factory.create("Chromaprinter",
                                          "maxLength", chromaprintDuration,
                                          "sampleRate", sampleRate);

    vector<Real> audio;
    string chromaprint;

    audioLoader->output("audio").set(audio);
    audioLoader->compute();

    chromaPrinter->input("signal").set(audio);
    chromaPrinter->output("fingerprint").set(chromaprint);
    chromaPrinter->compute();

    int duration = audio.size() / sampleRate;

    std::cout << "DURATION=" << duration << std::endl;
    std::cout << "FINGERPRINT=" << chromaprint << std::endl;

    shutdown();
}