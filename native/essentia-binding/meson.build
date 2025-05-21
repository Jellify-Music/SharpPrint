
project('essentia-bindings',
        ['cpp'],
        version: '0.0.1',
        default_options: ['cpp_std=c++20']
)

cpp = meson.get_compiler('cpp')

essentia_lib_dir = '/run/media/brys0/Storage/Projects/SharpPrint/SharpPrint/'

precomp_essentia_dep = cpp.find_library('libessentia', dirs: essentia_lib_dir)

shell_jni = shared_library(
        'essentia_bindings',
        'src/essentia-bindings.cpp',
        dependencies: [precomp_essentia_dep]  # Added opengl here
)