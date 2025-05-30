# SharpPrint

C# Bindings for some of *[Essentia](https://github.com/MTG/essentia)'s* main features. 

# Building
1. Run shell script `native/build-ubuntu.sh` 
2. Wait for release build to build
3. Manually remove the references of tensorflow inside the headers after cmake has installed the package
4. Build the essentia-binding package, and place the generated shared library somewhere your C# program can access it.
5. Cry if it breaks

# Using 
```csharp
 const float sampleRate = 44100;
        
 Essentia.init();
 AlgorithmFactory factory = new AlgorithmFactory();
 MonoLoader loader = new MonoLoader(factory, "/whatever track.mp3", sampleRate);
 ChromaPrinter chroma = new ChromaPrinter(factory, 3, sampleRate);

 string signature = chroma.Scan(loader);
        
 Console.WriteLine("Generated signature for song: " + signature);
 Essentia.destroy();
```

Created by [Brys0](https://github.com/brys0) in collaboration with [Jellify](https://github.com/Jellify-Music)