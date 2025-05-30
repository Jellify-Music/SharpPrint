echo 'Installing required packages for Ubuntu'

# This is from https://essentia.upf.edu/installing.html
sudo apt-get install build-essential libeigen3-dev libyaml-dev libfftw3-dev libavcodec-dev libavformat-dev libavutil-dev libswresample-dev libsamplerate0-dev libtag1-dev libchromaprint-dev -y

echo 'Done installing essential packages, installing python3 dependencies.'

# Install Python3 if it doesnt exist already
sudo apt-get install python3-dev python3-numpy-dev python3-numpy python3-yaml python3-six meson -y

cd essentia/ || echo "Failed to enter /essentia folder" && exit
echo "Building Essentia (if this doesn't work consider just installing essentia from your distro's pm)"

echo "Setting up build"
cmake -B build -D BUILD_EXAMPLES=OFF BUILD_VAMP_PLUGIN=ON USE_TENSORFLOW=OFF USE_GAIA2=ON

echo "Building.. (This will take awhile)"
cmake --build build --config Release

echo "Installing to /usr/local"
cmake --install build --config Release --prefix /usr/local

echo "Installed the libessentia package and it's headers.. (/usr/local/include/essentia)"

echo "In /usr/local/include/essentia you MUST MANUALLY REMOVE ANY REFERENCE TO TENSORFLOW PACKAGES, OR YOU WILL BE UNABLE TO BUILD THE BINDINGS!"

echo 'Next step: Building the libessentia bindings for CSharp (essentia-binding/)'
echo 'Run "meson build" to create /build dir, if you get an issue of an unresolved reference this is because you have not removed the references to tensorflow yet.'
echo 'You can compile using ninja -C build'