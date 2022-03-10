If you have the javascript in a js file, all you need to do is get ScriptEngineManager, create an object of ScriptEngine and then a FileInputStream to read the js file. Pass the bufferedreader as parameter to the eval function, something like this:

ScriptEngineManager manager = new ScriptEngineManager();
ScriptEngine engine = manager.getEngineByName("javascript");

FileInputStream fileInputStream = new FileInputStream("Path to your file here");
if (fileInputStream != null)
{
BufferedReader reader = new BufferedReader(new InputStreamReader(fileInputStream));
engine.eval(reader);

Invocable invocableEngine = (Invocable)javascriptEngine;
Object object = invocableEngine.invokeFunction("functionToBeCalled", parameterForTheFunction});
}




