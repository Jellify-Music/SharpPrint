
project('essentia-bindings',
        ['cpp'],
        version: '0.0.1',
        default_options: ['cpp_std=c++20']
)

cpp = meson.get_compiler('cpp')

# For now i've hard coded the path it searches for libessentia
precomp_essentia_dep = cpp.find_library('libessentia', dirs: '/usr/local/lib')

shell_jni = shared_library(
        'essentia_bindings',
        'src/essentia-bindings.cpp',
        install: true,
        dependencies: [precomp_essentia_dep]
)