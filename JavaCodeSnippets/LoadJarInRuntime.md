List<File> jars = Arrays.asList(new File("/tmp/jars").listFiles());
URL[] urls = new URL[files.size()];
for (int i = 0; i < jars.size(); i++) {
    try {
        urls[i] = jars.get(i).toURI().toURL();
    } catch (Exception e) {
        e.printStackTrace();
    }
}
URLClassLoader childClassLoader = new URLClassLoader(urls, ClassLoader.getSystemClassLoader());

Class.forName("org.kostenko.examples.core.classloader.ClassLoaderTest", true , childClassLoader);

Thread.currentThread().setContextClassLoader(childClassLoader);  

ServiceLoader<MyProvider> serviceLoader = ServiceLoader.load(MyProvider.class, childClassLoader);
