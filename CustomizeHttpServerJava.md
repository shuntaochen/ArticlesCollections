<div class="crayons-article__main">

          <div class="crayons-article__body text-styles spec__body" data-article-id="288043" id="article-body">
            <h1>
  <a name="one-of-the-most-frequency-used-protocol-in-the-whole-internet-" href="#one-of-the-most-frequency-used-protocol-in-the-whole-internet-" class="anchor">
  </a>
  One of the most frequency used protocol in the whole Internet *
</h1>

<p><strong>* In OSI model, layer 7</strong></p>

<p>Every time you visit a website your web browser uses the HTTP protocol to communicate with web server and fetch the page's content. Also, when you are implementing backend app and you have to communicate with other backend app - 80% (or more) of cases you will use the HTTP.</p>

<p>Long story short - when you want to be a good software developer, you have to know how the HTTP protocol works. And wiring the HTTP server is pretty good way to understood, I think.</p>

<h1>
  <a name="what-a-web-browser-sends-to-the-web-server" href="#what-a-web-browser-sends-to-the-web-server" class="anchor">
  </a>
  What a web browser sends to the web server?
</h1>

<p>Good question. Of course, you can use "developer tools", let's do it.</p>

<p><a href="https://res.cloudinary.com/practicaldev/image/fetch/s--UwcMxzQl--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/nirbu5zd2ht02n5z5y4v.png" class="article-body-image-wrapper"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--UwcMxzQl--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/nirbu5zd2ht02n5z5y4v.png" alt="Alt Text" loading="lazy"></a></p>

<p>Hmm... but what now? What exactly it means? We can see some URL, some method, some status, version (huh?), headers, and other stuff. Useful? Yes, but only to analyze the web app, when something is wrong. We still don't know how HTTP works.</p>

<h2>
  <a name="wireshark-my-old-friend" href="#wireshark-my-old-friend" class="anchor">
  </a>
  Wireshark, my old friend
</h2>

<p>The source of truth. Wireshark is application to analyze network traffic. You can use it to see each packet that is sent by your (or to your) PC.</p>

<p><a href="https://res.cloudinary.com/practicaldev/image/fetch/s--Ygz-av70--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/kzy95zlu6zk5gktg37uu.png" class="article-body-image-wrapper"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--Ygz-av70--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/kzy95zlu6zk5gktg37uu.png" alt="Alt Text" loading="lazy"></a></p>

<p>But to be honest - if you know how to use Wireshark - you probably know how HTTP and TCP works. It's pretty advanced program.</p>

<h2>
  <a name="you-are-right-the-specification" href="#you-are-right-the-specification" class="anchor">
  </a>
  You are right - the specification
</h2>

<p>Every good (I mean - used by more that 5 peoples) protocols should have specification. In this case it's called <a href="https://en.wikipedia.org/wiki/Request_for_Comments">RFC</a>. But don't lie - you will never read this, it's too long - <a href="https://tools.ietf.org/html/rfc2616">https://tools.ietf.org/html/rfc2616</a> . </p>

<h2>
  <a name="just-run-the-server-and-test" href="#just-run-the-server-and-test" class="anchor">
  </a>
  Just run the server and test
</h2>

<p>Joke? No. Probably you have installed on your PC very powerful tool called netcat, it's pretty advanced tool.<br>
One of the netcat features is TCP server. You can run the netcat to listen on specific port and print every thing what it gets. Netcat is a command line app.<br>
</p>

<div class="highlight js-code-highlight">
<pre class="highlight shell"><code>nc <span class="nt">-v</span> <span class="nt">-l</span> <span class="nt">-p</span> 8080
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Netcat (<em>nc</em>), please, listen (<em>-l</em>) on port 8080 (<em>-p 8080</em>) and print everything (<em>-v</em>).</p>

<p>Now open web browser and enter <code>http://localhost:8080/</code>. Your browser will send the HTTP request to the server runned by netcat. Of course <code>nc</code> will print the whole request and ignore it, browser will wait for the response (will timeout soon). To kill <code>nc</code> press <code>ctrl+c</code>.</p>

<p><a href="https://asciinema.org/a/313443"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--et1nUxIL--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://asciinema.org/a/313443.svg" alt="asciicast" loading="lazy"></a></p>

<p>So, finally, we have an HTTP request!<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>GET / HTTP/1.1
Host: localhost:8080
User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:74.0) Gecko/20100101 Firefox/74.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
Accept-Language: en-US,en;q=0.5
Accept-Encoding: gzip, deflate
Connection: keep-alive
Cookie: JSESSIONID=D3AF43EBFC0C9D92AD9C37823C4BB299
Upgrade-Insecure-Requests: 1

</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>As you can see - it fully texts protocol. No bits to analyze, just plain text.</p>
<h1>
  <a name="http-request" href="#http-request" class="anchor">
  </a>
  HTTP request
</h1>

<p>It may be a little confusing. Maybe <code>nc</code> parses the request before printing? HTTP protocol should be complicated, where is the sequence of 0 and 1? There aren't any. HTTP is really very simple <em>text</em> protocol. There is only one, little trap (I will explain it at the end of this section).</p>

<p>We can split the request to the 4 main parts:<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>GET / HTTP/1.1
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>This is the <em>main</em> request.</p>

<p><code>GET</code> - this is the HTTP method. Probably you know <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods">there are a lot of methods</a>.<br>
<code>GET</code> means <code>give me</code></p>

<p><code>/</code> - resource. <code>/</code> means <em>default one</em>. <br>
When you will open <code>localhost:8080/my_gf_nudes.html</code>, the resource will be <code>/my_gf_nudes.html</code></p>

<p><code>HTTP/1.1</code> - HTTP version. There are few versions, 1.1 is commonly used.<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>Host: localhost:8080
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Host. One server can host many domains, using this field, the browser says which domain it wants exactly<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>User-Agent: Mozilla/5.0 (Macintosh; Intel Mac OS X 10.15; rv:74.0) Gecko/20100101 Firefox/74.0
Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
Accept-Language: en-US,en;q=0.5
Accept-Encoding: gzip, deflate
Connection: keep-alive
Cookie: JSESSIONID=D3AF43EBFC0C9D92AD9C37823C4BB299
Upgrade-Insecure-Requests: 1
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Headers. In short: some additional informations. But I'm sure that you know what headers are :)<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Surprise - empty line. It means: end of the request. In general - empty line in HTTP means <em>end of section</em>.</p>
<h2>
  <a name="the-trap" href="#the-trap" class="anchor">
  </a>
  The trap
</h2>

<p>In HTTP every new line separator is a Window's new line. <code>\r\n</code> <strong>not</strong> <code>\n</code>. Remember.</p>
<h1>
  <a name="response" href="#response" class="anchor">
  </a>
  Response
</h1>

<p>Ok. We have a request. How does response look like? Send a request to any server and see, there is nothing simpler.<br>
On your laptop you can find another very useful tool - <code>telnet</code>. Using telenet you can open TCP connection, write something to server and print the response.<br>
Try to do it yourself. Run <code>telnet google.com 80</code> (80 is the default HTTP port) and type request manually (you know how it should look like). To close connection press <code>ctrl+]</code> than type <code>quit</code>.</p>

<p><a href="https://asciinema.org/a/313466"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--0MqYR32---/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://asciinema.org/a/313466.svg" alt="asciicast" loading="lazy"></a></p>

<p>OK. We have a response.<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>HTTP/1.1 301 Moved Permanently
Location: http://www.google.com/
Content-Type: text/html; charset=UTF-8
Date: Wed, 25 Mar 2020 18:53:12 GMT
Expires: Fri, 24 Apr 2020 18:53:12 GMT
Cache-Control: public, max-age=2592000
Server: gws
Content-Length: 219
X-XSS-Protection: 0
X-Frame-Options: SAMEORIGIN

&lt;HTML&gt;&lt;HEAD&gt;&lt;meta http-equiv="content-type" content="text/html;charset=utf-8"&gt;
&lt;TITLE&gt;301 Moved&lt;/TITLE&gt;&lt;/HEAD&gt;&lt;BODY&gt;
&lt;H1&gt;301 Moved&lt;/H1&gt;
The document has moved
&lt;A HREF="http://www.google.com/"&gt;here&lt;/A&gt;.
&lt;/BODY&gt;&lt;/HTML&gt;

</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>We can split it to 4 sections<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>HTTP/1.1 301 Moved Permanently
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p><code>HTTP/1.1</code> - version<br>
<code>301</code> - <a href="https://developer.mozilla.org/en-US/docs/Web/HTTP/Status">status code</a>. I believe you are familiar with that<br>
<code>Moved Permanently</code> - human-readable status code<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>Location: http://www.google.com/
Content-Type: text/html; charset=UTF-8
Date: Wed, 25 Mar 2020 18:53:12 GMT
Expires: Fri, 24 Apr 2020 18:53:12 GMT
Cache-Control: public, max-age=2592000
Server: gws
Content-Length: 219
X-XSS-Protection: 0
X-Frame-Options: SAMEORIGIN
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Headers<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Empty line, it means that the content will be sent in next section.<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>&lt;HTML&gt;&lt;HEAD&gt;&lt;meta http-equiv="content-type" content="text/html;charset=utf-8"&gt;
&lt;TITLE&gt;301 Moved&lt;/TITLE&gt;&lt;/HEAD&gt;&lt;BODY&gt;
&lt;H1&gt;301 Moved&lt;/H1&gt;
The document has moved
&lt;A HREF="http://www.google.com/"&gt;here&lt;/A&gt;.
&lt;/BODY&gt;&lt;/HTML&gt;
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Content, HTML or binary or something<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Empty line, means <em>end of request</em>.</p>

<p><strong>REMEMBER: each new line is <code>\r\n</code></strong></p>
<h1>
  <a name="time-for-programming" href="#time-for-programming" class="anchor">
  </a>
  Time for programming!
</h1>

<p>We know how request look like, we know how response look like, it's time to implement our server.</p>
<h2>
  <a name="what-we-expect" href="#what-we-expect" class="anchor">
  </a>
  What we expect
</h2>

<p>We want to get a very simple thing - to display an HTML page and a picture in a browser.<br>
Let's prepare two HTMLs files and one picture<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>❯ pwd
/tmp/www

❯ ls
gallery.html index.html   me.jpg

❯ cat index.html
&lt;html&gt;
  &lt;header&gt;
    &lt;title&gt;My homepage!&lt;/title&gt;
  &lt;/header&gt;
  &lt;body&gt;
    &lt;h1&gt;Welcome!&lt;/h1&gt;
    &lt;p&gt;&lt;a href="gallery.html"&gt;Here&lt;/a&gt; you can look at my pictures&lt;/p&gt;
  &lt;/body&gt;
&lt;/html&gt;

❯ cat gallery.html
&lt;html&gt;
  &lt;head&gt;
    &lt;title&gt;Gallery&lt;/title&gt;
  &lt;/head&gt;
  &lt;body&gt;
    &lt;h1&gt;My sexi photos&lt;h1&gt;
    &lt;img src="me.jpg" /&gt;
  &lt;/body&gt;
&lt;/html&gt;

❯
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>

<h2>
  <a name="the-plan" href="#the-plan" class="anchor">
  </a>
  The plan
</h2>

<p>Plan is very simple:</p>

<ol>
<li>Open TCP socket and listen</li>
<li>Accept the client and read request</li>
<li>Parse the request</li>
<li>Find requested resource on disk</li>
<li>Send the response </li>
<li>Test</li>
</ol>
<h2>
  <a name="open-tcp-socket" href="#open-tcp-socket" class="anchor">
  </a>
  Open TCP socket
</h2>

<p>In this article we will use <code>ServerSocket</code> class to handle TCP connection. As a homework you can reimplement the server to use the classes from the <code>nio</code> packages.</p>

<p>So, open your IDE and let's start.<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>    <span class="kd">public</span> <span class="kd">static</span> <span class="kt">void</span> <span class="nf">main</span><span class="o">(</span> <span class="nc">String</span><span class="o">[]</span> <span class="n">args</span> <span class="o">)</span> <span class="kd">throws</span> <span class="nc">Exception</span> <span class="o">{</span>
        <span class="k">try</span> <span class="o">(</span><span class="nc">ServerSocket</span> <span class="n">serverSocket</span> <span class="o">=</span> <span class="k">new</span> <span class="nc">ServerSocket</span><span class="o">(</span><span class="mi">8080</span><span class="o">))</span> <span class="o">{</span>
            <span class="k">while</span> <span class="o">(</span><span class="kc">true</span><span class="o">)</span> <span class="o">{</span>
                <span class="c1">// implement client handler here</span>
            <span class="o">}</span>
        <span class="o">}</span>
    <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>I want to keep the code concise and clean - it's why I <code>throws Exception</code> instead of implementing good exception handling.<br>
So as I told, we have to open socket on port 8080 (why not 80? Because to use low port you need root privileges).<br>
We also need the infinity loop to 'pause the server'.</p>

<p>User <code>telnet</code> to test the socket:<br>
<a href="https://res.cloudinary.com/practicaldev/image/fetch/s--9HrU-p0h--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/j7o15563jz5wacqsiql2.png" class="article-body-image-wrapper"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--9HrU-p0h--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/j7o15563jz5wacqsiql2.png" alt="Alt Text" loading="lazy"></a><br>
Perfect, works.</p>
<h2>
  <a name="accept-client-connection" href="#accept-client-connection" class="anchor">
  </a>
  Accept client connection
</h2>


<div class="highlight js-code-highlight">
<pre class="highlight java"><code>        <span class="k">try</span> <span class="o">(</span><span class="nc">ServerSocket</span> <span class="n">serverSocket</span> <span class="o">=</span> <span class="k">new</span> <span class="nc">ServerSocket</span><span class="o">(</span><span class="mi">8080</span><span class="o">))</span> <span class="o">{</span>
            <span class="k">while</span> <span class="o">(</span><span class="kc">true</span><span class="o">)</span> <span class="o">{</span>
                <span class="k">try</span> <span class="o">(</span><span class="nc">Socket</span> <span class="n">client</span> <span class="o">=</span> <span class="n">serverSocket</span><span class="o">.</span><span class="na">accept</span><span class="o">())</span> <span class="o">{</span>
                    <span class="n">handleClient</span><span class="o">(</span><span class="n">client</span><span class="o">);</span>
                <span class="o">}</span>
            <span class="o">}</span>
        <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>To accept connection from client we have to call <strong>blocking</strong> <code>accept()</code> method. Java program will wait for a client on that line.</p>

<p>Time to implement the client handler:<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>    <span class="kd">private</span> <span class="kd">static</span> <span class="kt">void</span> <span class="nf">handleClient</span><span class="o">(</span><span class="nc">Socket</span> <span class="n">client</span><span class="o">)</span> <span class="kd">throws</span> <span class="nc">IOException</span> <span class="o">{</span>
        <span class="nc">System</span><span class="o">.</span><span class="na">out</span><span class="o">.</span><span class="na">println</span><span class="o">(</span><span class="s">"Debug: got new client "</span> <span class="o">+</span> <span class="n">client</span><span class="o">.</span><span class="na">toString</span><span class="o">());</span>
        <span class="nc">BufferedReader</span> <span class="n">br</span> <span class="o">=</span> <span class="k">new</span> <span class="nc">BufferedReader</span><span class="o">(</span><span class="k">new</span> <span class="nc">InputStreamReader</span><span class="o">(</span><span class="n">client</span><span class="o">.</span><span class="na">getInputStream</span><span class="o">()));</span>

        <span class="nc">StringBuilder</span> <span class="n">requestBuilder</span> <span class="o">=</span> <span class="k">new</span> <span class="nc">StringBuilder</span><span class="o">();</span>
        <span class="nc">String</span> <span class="n">line</span><span class="o">;</span>
        <span class="k">while</span> <span class="o">(!(</span><span class="n">line</span> <span class="o">=</span> <span class="n">br</span><span class="o">.</span><span class="na">readLine</span><span class="o">()).</span><span class="na">isBlank</span><span class="o">())</span> <span class="o">{</span>
            <span class="n">requestBuilder</span><span class="o">.</span><span class="na">append</span><span class="o">(</span><span class="n">line</span> <span class="o">+</span> <span class="s">"\r\n"</span><span class="o">);</span>
        <span class="o">}</span>

        <span class="nc">String</span> <span class="n">request</span> <span class="o">=</span> <span class="n">requestBuilder</span><span class="o">.</span><span class="na">toString</span><span class="o">();</span>
        <span class="nc">System</span><span class="o">.</span><span class="na">out</span><span class="o">.</span><span class="na">println</span><span class="o">(</span><span class="n">request</span><span class="o">);</span>
    <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>We have to read the request. How? Just read the input stream from the client's socket. In Java it's not so simple, that's why I made this ugly line<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>new BufferedReader(new InputStreamReader(client.getInputStream()));
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Well, Java.</p>

<p>Request ends with one empty line (<code>\r\n</code>), remember? Client will send empty line, but imputStream will be still open, we have to read it until one, empty line arrives.</p>

<p>Run the server, go to <code>http://localhost:8080/</code> and observe logs:<br>
<a href="https://res.cloudinary.com/practicaldev/image/fetch/s--g1QqERGb--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/brk5ufjsxg9slfexlcr2.png" class="article-body-image-wrapper"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--g1QqERGb--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/brk5ufjsxg9slfexlcr2.png" alt="Alt Text" loading="lazy"></a><br>
It works! We can log the whole request!</p>
<h2>
  <a name="parse-the-request" href="#parse-the-request" class="anchor">
  </a>
  Parse the request
</h2>

<p>Parsing the request is realy simple, I don't think there's any need for further explanation<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>        <span class="nc">String</span> <span class="n">request</span> <span class="o">=</span> <span class="n">requestBuilder</span><span class="o">.</span><span class="na">toString</span><span class="o">();</span>
        <span class="nc">String</span><span class="o">[]</span> <span class="n">requestsLines</span> <span class="o">=</span> <span class="n">request</span><span class="o">.</span><span class="na">split</span><span class="o">(</span><span class="s">"\r\n"</span><span class="o">);</span>
        <span class="nc">String</span><span class="o">[]</span> <span class="n">requestLine</span> <span class="o">=</span> <span class="n">requestsLines</span><span class="o">[</span><span class="mi">0</span><span class="o">].</span><span class="na">split</span><span class="o">(</span><span class="s">" "</span><span class="o">);</span>
        <span class="nc">String</span> <span class="n">method</span> <span class="o">=</span> <span class="n">requestLine</span><span class="o">[</span><span class="mi">0</span><span class="o">];</span>
        <span class="nc">String</span> <span class="n">path</span> <span class="o">=</span> <span class="n">requestLine</span><span class="o">[</span><span class="mi">1</span><span class="o">];</span>
        <span class="nc">String</span> <span class="n">version</span> <span class="o">=</span> <span class="n">requestLine</span><span class="o">[</span><span class="mi">2</span><span class="o">];</span>
        <span class="nc">String</span> <span class="n">host</span> <span class="o">=</span> <span class="n">requestsLines</span><span class="o">[</span><span class="mi">1</span><span class="o">].</span><span class="na">split</span><span class="o">(</span><span class="s">" "</span><span class="o">)[</span><span class="mi">1</span><span class="o">];</span>

        <span class="nc">List</span><span class="o">&lt;</span><span class="nc">String</span><span class="o">&gt;</span> <span class="n">headers</span> <span class="o">=</span> <span class="k">new</span> <span class="nc">ArrayList</span><span class="o">&lt;&gt;();</span>
        <span class="k">for</span> <span class="o">(</span><span class="kt">int</span> <span class="n">h</span> <span class="o">=</span> <span class="mi">2</span><span class="o">;</span> <span class="n">h</span> <span class="o">&lt;</span> <span class="n">requestsLines</span><span class="o">.</span><span class="na">length</span><span class="o">;</span> <span class="n">h</span><span class="o">++)</span> <span class="o">{</span>
            <span class="nc">String</span> <span class="n">header</span> <span class="o">=</span> <span class="n">requestsLines</span><span class="o">[</span><span class="n">h</span><span class="o">];</span>
            <span class="n">headers</span><span class="o">.</span><span class="na">add</span><span class="o">(</span><span class="n">header</span><span class="o">);</span>
        <span class="o">}</span>

        <span class="nc">String</span> <span class="n">accessLog</span> <span class="o">=</span> <span class="nc">String</span><span class="o">.</span><span class="na">format</span><span class="o">(</span><span class="s">"Client %s, method %s, path %s, version %s, host %s, headers %s"</span><span class="o">,</span>
                <span class="n">client</span><span class="o">.</span><span class="na">toString</span><span class="o">(),</span> <span class="n">method</span><span class="o">,</span> <span class="n">path</span><span class="o">,</span> <span class="n">version</span><span class="o">,</span> <span class="n">host</span><span class="o">,</span> <span class="n">headers</span><span class="o">.</span><span class="na">toString</span><span class="o">());</span>
        <span class="nc">System</span><span class="o">.</span><span class="na">out</span><span class="o">.</span><span class="na">println</span><span class="o">(</span><span class="n">accessLog</span><span class="o">);</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Just some splits. The only one thing that you may not understand is why we started the loop from 2? Because first line (index 0) is <code>GET / HTTP/1.1</code>, second line is host. The headers start with the third line of the request</p>
<h2>
  <a name="send-response" href="#send-response" class="anchor">
  </a>
  Send response
</h2>

<p>We will send the response to the client's output stream.<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>        <span class="nc">OutputStream</span> <span class="n">clientOutput</span> <span class="o">=</span> <span class="n">client</span><span class="o">.</span><span class="na">getOutputStream</span><span class="o">();</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="s">"HTTP/1.1 200 OK\r\n"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">((</span><span class="s">"ContentType: text/html\r\n"</span><span class="o">).</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="s">"\r\n"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="s">"&lt;b&gt;It works!&lt;/b&gt;"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="s">"\r\n\r\n"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">flush</span><span class="o">();</span>
        <span class="n">client</span><span class="o">.</span><span class="na">close</span><span class="o">();</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Do you remember how response should look like?<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight plaintext"><code>version status code
headers
(empty line)
content
(empty line)
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Don't forget to close the output stream.</p>

<p><a href="https://res.cloudinary.com/practicaldev/image/fetch/s--nDvHO0ih--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/sovsf8l7txub2sxksa8r.png" class="article-body-image-wrapper"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--nDvHO0ih--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/sovsf8l7txub2sxksa8r.png" alt="Alt Text" loading="lazy"></a><br>
Wow, it's really works</p>
<h2>
  <a name="find-requested-resource" href="#find-requested-resource" class="anchor">
  </a>
  Find requested resource
</h2>

<p>We have to implement two methods first<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>    <span class="kd">private</span> <span class="kd">static</span> <span class="nc">String</span> <span class="nf">guessContentType</span><span class="o">(</span><span class="nc">Path</span> <span class="n">filePath</span><span class="o">)</span> <span class="kd">throws</span> <span class="nc">IOException</span> <span class="o">{</span>
        <span class="k">return</span> <span class="nc">Files</span><span class="o">.</span><span class="na">probeContentType</span><span class="o">(</span><span class="n">filePath</span><span class="o">);</span>
    <span class="o">}</span>

    <span class="kd">private</span> <span class="kd">static</span> <span class="nc">Path</span> <span class="nf">getFilePath</span><span class="o">(</span><span class="nc">String</span> <span class="n">path</span><span class="o">)</span> <span class="o">{</span>
        <span class="k">if</span> <span class="o">(</span><span class="s">"/"</span><span class="o">.</span><span class="na">equals</span><span class="o">(</span><span class="n">path</span><span class="o">))</span> <span class="o">{</span>
            <span class="n">path</span> <span class="o">=</span> <span class="s">"/index.html"</span><span class="o">;</span>
        <span class="o">}</span>

        <span class="k">return</span> <span class="nc">Paths</span><span class="o">.</span><span class="na">get</span><span class="o">(</span><span class="s">"/tmp/www"</span><span class="o">,</span> <span class="n">path</span><span class="o">);</span>
    <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p><code>guessContentType</code> - we have to tell to the browser what kind of content we are sending. It's callend <code>content type</code>. Fortunately, there are built-in mechanisms in Java for this. We don't have to make a big switch block.</p>

<p><code>getFilePath</code> - Before we will return the file - we need to known it location.<br>
This condition deserves attention<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>        <span class="k">if</span> <span class="o">(</span><span class="s">"/"</span><span class="o">.</span><span class="na">equals</span><span class="o">(</span><span class="n">path</span><span class="o">))</span> <span class="o">{</span>
            <span class="n">path</span> <span class="o">=</span> <span class="s">"/index.html"</span><span class="o">;</span>
        <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>If user wants <em>default resource</em> then return <code>index.html</code>.</p>
<h2>
  <a name="send-the-response" href="#send-the-response" class="anchor">
  </a>
  send the response
</h2>

<p>Do you remember the code that sends response to the user (block of <code>clientOutput.write</code>)? We need to move it to the method<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>    <span class="kd">private</span> <span class="kd">static</span> <span class="kt">void</span> <span class="nf">sendResponse</span><span class="o">(</span><span class="nc">Socket</span> <span class="n">client</span><span class="o">,</span> <span class="nc">String</span> <span class="n">status</span><span class="o">,</span> <span class="nc">String</span> <span class="n">contentType</span><span class="o">,</span> <span class="kt">byte</span><span class="o">[]</span> <span class="n">content</span><span class="o">)</span> <span class="kd">throws</span> <span class="nc">IOException</span> <span class="o">{</span>
        <span class="nc">OutputStream</span> <span class="n">clientOutput</span> <span class="o">=</span> <span class="n">client</span><span class="o">.</span><span class="na">getOutputStream</span><span class="o">();</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">((</span><span class="s">"HTTP/1.1 \r\n"</span> <span class="o">+</span> <span class="n">status</span><span class="o">).</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">((</span><span class="s">"ContentType: "</span> <span class="o">+</span> <span class="n">contentType</span> <span class="o">+</span> <span class="s">"\r\n"</span><span class="o">).</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="s">"\r\n"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="n">content</span><span class="o">);</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">write</span><span class="o">(</span><span class="s">"\r\n\r\n"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">());</span>
        <span class="n">clientOutput</span><span class="o">.</span><span class="na">flush</span><span class="o">();</span>
        <span class="n">client</span><span class="o">.</span><span class="na">close</span><span class="o">();</span>
    <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>


<p>Ok, finally we can return the file<br>
</p>
<div class="highlight js-code-highlight">
<pre class="highlight java"><code>        <span class="nc">Path</span> <span class="n">filePath</span> <span class="o">=</span> <span class="n">getFilePath</span><span class="o">(</span><span class="n">path</span><span class="o">);</span>
        <span class="k">if</span> <span class="o">(</span><span class="nc">Files</span><span class="o">.</span><span class="na">exists</span><span class="o">(</span><span class="n">filePath</span><span class="o">))</span> <span class="o">{</span>
            <span class="c1">// file exist</span>
            <span class="nc">String</span> <span class="n">contentType</span> <span class="o">=</span> <span class="n">guessContentType</span><span class="o">(</span><span class="n">filePath</span><span class="o">);</span>
            <span class="n">sendResponse</span><span class="o">(</span><span class="n">client</span><span class="o">,</span> <span class="s">"200 OK"</span><span class="o">,</span> <span class="n">contentType</span><span class="o">,</span> <span class="nc">Files</span><span class="o">.</span><span class="na">readAllBytes</span><span class="o">(</span><span class="n">filePath</span><span class="o">));</span>
        <span class="o">}</span> <span class="k">else</span> <span class="o">{</span>
            <span class="c1">// 404</span>
            <span class="kt">byte</span><span class="o">[]</span> <span class="n">notFoundContent</span> <span class="o">=</span> <span class="s">"&lt;h1&gt;Not found :(&lt;/h1&gt;"</span><span class="o">.</span><span class="na">getBytes</span><span class="o">();</span>
            <span class="n">sendResponse</span><span class="o">(</span><span class="n">client</span><span class="o">,</span> <span class="s">"404 Not Found"</span><span class="o">,</span> <span class="s">"text/html"</span><span class="o">,</span> <span class="n">notFoundContent</span><span class="o">);</span>
        <span class="o">}</span>
</code></pre>
<div class="highlight__panel js-actions-panel">
<div class="highlight__panel-action js-fullscreen-code-action">
    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-on"><title>Enter fullscreen mode</title>
    <path d="M16 3h6v6h-2V5h-4V3zM2 3h6v2H4v4H2V3zm18 16v-4h2v6h-6v-2h4zM4 19h4v2H2v-6h2v4z"></path>
</svg>

    <svg xmlns="http://www.w3.org/2000/svg" width="20px" height="20px" viewBox="0 0 24 24" class="highlight-action crayons-icon highlight-action--fullscreen-off"><title>Exit fullscreen mode</title>
    <path d="M18 7h4v2h-6V3h2v4zM8 9H2V7h4V3h2v6zm10 8v4h-2v-6h6v2h-4zM8 15v6H6v-4H2v-2h6z"></path>
</svg>

</div>
</div>
</div>

<h1>
  <a name="it-works" href="#it-works" class="anchor">
  </a>
  It works!
</h1>

<p><a href="https://res.cloudinary.com/practicaldev/image/fetch/s--8fp1ox7j--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/ek7l4fb12a7j5u6pgbuc.png" class="article-body-image-wrapper"><img src="https://res.cloudinary.com/practicaldev/image/fetch/s--8fp1ox7j--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://dev-to-uploads.s3.amazonaws.com/i/ek7l4fb12a7j5u6pgbuc.png" alt="Alt Text" loading="lazy"></a><br>
Finally, we can see html page served by our web server!</p>
<h1>
  <a name="homework" href="#homework" class="anchor">
  </a>
  Homework
</h1>

<ol>
<li>Make it multi-thread.

<ol>
<li>Create thread pool</li>
<li>Move <code>handleClient</code> method to separated class and run it in new thread</li>
</ol>
</li>
<li>Rewrite it using non-blocking IO </li>
<li>Implement POST method

<ol>
<li>Start netcat</li>
<li>Send some HTML form</li>
<li>Analyze request</li>
</ol>
</li>
</ol>
<h1>
  <a name="full-source-code" href="#full-source-code" class="anchor">
  </a>
  Full source code
</h1>


<div class="ltag_gist-liquid-tag">
  <link rel="stylesheet" href="https://github.githubassets.com/assets/gist-embed-51d58df8adad.css"><div id="gist102000246" class="gist">
    <div class="gist-file" translate="no">
      <div class="gist-data">
        <div class="js-gist-file-update-container js-task-list-container file-box">
  <div id="file-server-java" class="file my-2">
    
  <div itemprop="text" class="Box-body p-0 blob-wrapper data type-java  ">

      
<div class="js-check-bidi js-blob-code-container blob-code-content">

  <template class="js-file-alert-template">
  <div data-view-component="true" class="flash flash-warn flash-full d-flex flex-items-center">
  <svg aria-hidden="true" height="16" viewBox="0 0 16 16" version="1.1" width="16" data-view-component="true" class="octicon octicon-alert">
    <path fill-rule="evenodd" d="M8.22 1.754a.25.25 0 00-.44 0L1.698 13.132a.25.25 0 00.22.368h12.164a.25.25 0 00.22-.368L8.22 1.754zm-1.763-.707c.659-1.234 2.427-1.234 3.086 0l6.082 11.378A1.75 1.75 0 0114.082 15H1.918a1.75 1.75 0 01-1.543-2.575L6.457 1.047zM9 11a1 1 0 11-2 0 1 1 0 012 0zm-.25-5.25a.75.75 0 00-1.5 0v2.5a.75.75 0 001.5 0v-2.5z"></path>
</svg>
  
    <span>
      This file contains bidirectional Unicode text that may be interpreted or compiled differently than what appears below. To review, open the file in an editor that reveals hidden Unicode characters.
      <a href="https://github.co/hiddenchars" target="_blank">Learn more about bidirectional Unicode characters</a>
    </span>


  <div data-view-component="true" class="flash-action">        <a href="{{ revealButtonHref }}" data-view-component="true" class="btn-sm btn">  Show hidden characters
</a>
</div>
</div></template>
<template class="js-line-alert-template">
  <span aria-label="This line has hidden Unicode characters" data-view-component="true" class="line-alert tooltipped tooltipped-e">
    <svg aria-hidden="true" height="16" viewBox="0 0 16 16" version="1.1" width="16" data-view-component="true" class="octicon octicon-alert">
    <path fill-rule="evenodd" d="M8.22 1.754a.25.25 0 00-.44 0L1.698 13.132a.25.25 0 00.22.368h12.164a.25.25 0 00.22-.368L8.22 1.754zm-1.763-.707c.659-1.234 2.427-1.234 3.086 0l6.082 11.378A1.75 1.75 0 0114.082 15H1.918a1.75 1.75 0 01-1.543-2.575L6.457 1.047zM9 11a1 1 0 11-2 0 1 1 0 012 0zm-.25-5.25a.75.75 0 00-1.5 0v2.5a.75.75 0 001.5 0v-2.5z"></path>
</svg>
</span></template>

  <table class="highlight tab-size js-file-line-container js-code-nav-container js-tagsearch-file" data-tab-size="8" data-paste-markdown-skip="" data-tagsearch-lang="Java" data-tagsearch-path="Server.java">
        <tbody><tr>
          <td id="file-server-java-L1" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="1"></td>
          <td id="file-server-java-LC1" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.io.*</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L2" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="2"></td>
          <td id="file-server-java-LC2" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.net.ServerSocket</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L3" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="3"></td>
          <td id="file-server-java-LC3" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.net.Socket</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L4" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="4"></td>
          <td id="file-server-java-LC4" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.nio.file.Files</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L5" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="5"></td>
          <td id="file-server-java-LC5" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.nio.file.Path</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L6" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="6"></td>
          <td id="file-server-java-LC6" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.nio.file.Paths</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L7" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="7"></td>
          <td id="file-server-java-LC7" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.util.ArrayList</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L8" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="8"></td>
          <td id="file-server-java-LC8" class="blob-code blob-code-inner js-file-line"><span class="pl-k">import</span> <span class="pl-smi">java.util.List</span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L9" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="9"></td>
          <td id="file-server-java-LC9" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L10" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="10"></td>
          <td id="file-server-java-LC10" class="blob-code blob-code-inner js-file-line"><span class="pl-c"><span class="pl-c">//</span> Read the full article https://dev.to/mateuszjarzyna/build-your-own-http-server-in-java-in-less-than-one-hour-only-get-method-2k02</span></td>
        </tr>
        <tr>
          <td id="file-server-java-L11" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="11"></td>
          <td id="file-server-java-LC11" class="blob-code blob-code-inner js-file-line"><span class="pl-k">public</span> <span class="pl-k">class</span> <span class="pl-en">Server</span> {</td>
        </tr>
        <tr>
          <td id="file-server-java-L12" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="12"></td>
          <td id="file-server-java-LC12" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L13" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="13"></td>
          <td id="file-server-java-LC13" class="blob-code blob-code-inner js-file-line">    <span class="pl-k">public</span> <span class="pl-k">static</span> <span class="pl-k">void</span> <span class="pl-en">main</span>( <span class="pl-k">String</span>[] <span class="pl-v">args</span> ) <span class="pl-k">throws</span> <span class="pl-smi">Exception</span> {</td>
        </tr>
        <tr>
          <td id="file-server-java-L14" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="14"></td>
          <td id="file-server-java-LC14" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">try</span> (<span class="pl-smi">ServerSocket</span> serverSocket <span class="pl-k">=</span> <span class="pl-k">new</span> <span class="pl-smi">ServerSocket</span>(<span class="pl-c1">8080</span>)) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L15" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="15"></td>
          <td id="file-server-java-LC15" class="blob-code blob-code-inner js-file-line">            <span class="pl-k">while</span> (<span class="pl-c1">true</span>) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L16" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="16"></td>
          <td id="file-server-java-LC16" class="blob-code blob-code-inner js-file-line">                <span class="pl-k">try</span> (<span class="pl-smi">Socket</span> client <span class="pl-k">=</span> serverSocket<span class="pl-k">.</span>accept()) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L17" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="17"></td>
          <td id="file-server-java-LC17" class="blob-code blob-code-inner js-file-line">                    handleClient(client);</td>
        </tr>
        <tr>
          <td id="file-server-java-L18" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="18"></td>
          <td id="file-server-java-LC18" class="blob-code blob-code-inner js-file-line">                }</td>
        </tr>
        <tr>
          <td id="file-server-java-L19" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="19"></td>
          <td id="file-server-java-LC19" class="blob-code blob-code-inner js-file-line">            }</td>
        </tr>
        <tr>
          <td id="file-server-java-L20" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="20"></td>
          <td id="file-server-java-LC20" class="blob-code blob-code-inner js-file-line">        }</td>
        </tr>
        <tr>
          <td id="file-server-java-L21" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="21"></td>
          <td id="file-server-java-LC21" class="blob-code blob-code-inner js-file-line">    }</td>
        </tr>
        <tr>
          <td id="file-server-java-L22" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="22"></td>
          <td id="file-server-java-LC22" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L23" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="23"></td>
          <td id="file-server-java-LC23" class="blob-code blob-code-inner js-file-line">    <span class="pl-k">private</span> <span class="pl-k">static</span> <span class="pl-k">void</span> <span class="pl-en">handleClient</span>(<span class="pl-smi">Socket</span> <span class="pl-v">client</span>) <span class="pl-k">throws</span> <span class="pl-smi">IOException</span> {</td>
        </tr>
        <tr>
          <td id="file-server-java-L24" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="24"></td>
          <td id="file-server-java-LC24" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">BufferedReader</span> br <span class="pl-k">=</span> <span class="pl-k">new</span> <span class="pl-smi">BufferedReader</span>(<span class="pl-k">new</span> <span class="pl-smi">InputStreamReader</span>(client<span class="pl-k">.</span>getInputStream()));</td>
        </tr>
        <tr>
          <td id="file-server-java-L25" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="25"></td>
          <td id="file-server-java-LC25" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L26" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="26"></td>
          <td id="file-server-java-LC26" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">StringBuilder</span> requestBuilder <span class="pl-k">=</span> <span class="pl-k">new</span> <span class="pl-smi">StringBuilder</span>();</td>
        </tr>
        <tr>
          <td id="file-server-java-L27" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="27"></td>
          <td id="file-server-java-LC27" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> line;</td>
        </tr>
        <tr>
          <td id="file-server-java-L28" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="28"></td>
          <td id="file-server-java-LC28" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">while</span> (<span class="pl-k">!</span>(line <span class="pl-k">=</span> br<span class="pl-k">.</span>readLine())<span class="pl-k">.</span>isBlank()) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L29" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="29"></td>
          <td id="file-server-java-LC29" class="blob-code blob-code-inner js-file-line">            requestBuilder<span class="pl-k">.</span>append(line <span class="pl-k">+</span> <span class="pl-s"><span class="pl-pds">"</span><span class="pl-cce">\r\n</span><span class="pl-pds">"</span></span>);</td>
        </tr>
        <tr>
          <td id="file-server-java-L30" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="30"></td>
          <td id="file-server-java-LC30" class="blob-code blob-code-inner js-file-line">        }</td>
        </tr>
        <tr>
          <td id="file-server-java-L31" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="31"></td>
          <td id="file-server-java-LC31" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L32" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="32"></td>
          <td id="file-server-java-LC32" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> request <span class="pl-k">=</span> requestBuilder<span class="pl-k">.</span>toString();</td>
        </tr>
        <tr>
          <td id="file-server-java-L33" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="33"></td>
          <td id="file-server-java-LC33" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">String</span>[] requestsLines <span class="pl-k">=</span> request<span class="pl-k">.</span>split(<span class="pl-s"><span class="pl-pds">"</span><span class="pl-cce">\r\n</span><span class="pl-pds">"</span></span>);</td>
        </tr>
        <tr>
          <td id="file-server-java-L34" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="34"></td>
          <td id="file-server-java-LC34" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">String</span>[] requestLine <span class="pl-k">=</span> requestsLines[<span class="pl-c1">0</span>]<span class="pl-k">.</span>split(<span class="pl-s"><span class="pl-pds">"</span> <span class="pl-pds">"</span></span>);</td>
        </tr>
        <tr>
          <td id="file-server-java-L35" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="35"></td>
          <td id="file-server-java-LC35" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> method <span class="pl-k">=</span> requestLine[<span class="pl-c1">0</span>];</td>
        </tr>
        <tr>
          <td id="file-server-java-L36" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="36"></td>
          <td id="file-server-java-LC36" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> path <span class="pl-k">=</span> requestLine[<span class="pl-c1">1</span>];</td>
        </tr>
        <tr>
          <td id="file-server-java-L37" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="37"></td>
          <td id="file-server-java-LC37" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> version <span class="pl-k">=</span> requestLine[<span class="pl-c1">2</span>];</td>
        </tr>
        <tr>
          <td id="file-server-java-L38" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="38"></td>
          <td id="file-server-java-LC38" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> host <span class="pl-k">=</span> requestsLines[<span class="pl-c1">1</span>]<span class="pl-k">.</span>split(<span class="pl-s"><span class="pl-pds">"</span> <span class="pl-pds">"</span></span>)[<span class="pl-c1">1</span>];</td>
        </tr>
        <tr>
          <td id="file-server-java-L39" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="39"></td>
          <td id="file-server-java-LC39" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L40" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="40"></td>
          <td id="file-server-java-LC40" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">List&lt;<span class="pl-smi">String</span>&gt;</span> headers <span class="pl-k">=</span> <span class="pl-k">new</span> <span class="pl-k">ArrayList&lt;&gt;</span>();</td>
        </tr>
        <tr>
          <td id="file-server-java-L41" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="41"></td>
          <td id="file-server-java-LC41" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">for</span> (<span class="pl-k">int</span> h <span class="pl-k">=</span> <span class="pl-c1">2</span>; h <span class="pl-k">&lt;</span> requestsLines<span class="pl-k">.</span>length; h<span class="pl-k">++</span>) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L42" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="42"></td>
          <td id="file-server-java-LC42" class="blob-code blob-code-inner js-file-line">            <span class="pl-smi">String</span> header <span class="pl-k">=</span> requestsLines[h];</td>
        </tr>
        <tr>
          <td id="file-server-java-L43" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="43"></td>
          <td id="file-server-java-LC43" class="blob-code blob-code-inner js-file-line">            headers<span class="pl-k">.</span>add(header);</td>
        </tr>
        <tr>
          <td id="file-server-java-L44" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="44"></td>
          <td id="file-server-java-LC44" class="blob-code blob-code-inner js-file-line">        }</td>
        </tr>
        <tr>
          <td id="file-server-java-L45" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="45"></td>
          <td id="file-server-java-LC45" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L46" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="46"></td>
          <td id="file-server-java-LC46" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">String</span> accessLog <span class="pl-k">=</span> <span class="pl-smi">String</span><span class="pl-k">.</span>format(<span class="pl-s"><span class="pl-pds">"</span>Client %s, method %s, path %s, version %s, host %s, headers %s<span class="pl-pds">"</span></span>,</td>
        </tr>
        <tr>
          <td id="file-server-java-L47" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="47"></td>
          <td id="file-server-java-LC47" class="blob-code blob-code-inner js-file-line">                client<span class="pl-k">.</span>toString(), method, path, version, host, headers<span class="pl-k">.</span>toString());</td>
        </tr>
        <tr>
          <td id="file-server-java-L48" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="48"></td>
          <td id="file-server-java-LC48" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">System</span><span class="pl-k">.</span>out<span class="pl-k">.</span>println(accessLog);</td>
        </tr>
        <tr>
          <td id="file-server-java-L49" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="49"></td>
          <td id="file-server-java-LC49" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L50" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="50"></td>
          <td id="file-server-java-LC50" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L51" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="51"></td>
          <td id="file-server-java-LC51" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">Path</span> filePath <span class="pl-k">=</span> getFilePath(path);</td>
        </tr>
        <tr>
          <td id="file-server-java-L52" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="52"></td>
          <td id="file-server-java-LC52" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">if</span> (<span class="pl-smi">Files</span><span class="pl-k">.</span>exists(filePath)) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L53" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="53"></td>
          <td id="file-server-java-LC53" class="blob-code blob-code-inner js-file-line">            <span class="pl-c"><span class="pl-c">//</span> file exist</span></td>
        </tr>
        <tr>
          <td id="file-server-java-L54" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="54"></td>
          <td id="file-server-java-LC54" class="blob-code blob-code-inner js-file-line">            <span class="pl-smi">String</span> contentType <span class="pl-k">=</span> guessContentType(filePath);</td>
        </tr>
        <tr>
          <td id="file-server-java-L55" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="55"></td>
          <td id="file-server-java-LC55" class="blob-code blob-code-inner js-file-line">            sendResponse(client, <span class="pl-s"><span class="pl-pds">"</span>200 OK<span class="pl-pds">"</span></span>, contentType, <span class="pl-smi">Files</span><span class="pl-k">.</span>readAllBytes(filePath));</td>
        </tr>
        <tr>
          <td id="file-server-java-L56" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="56"></td>
          <td id="file-server-java-LC56" class="blob-code blob-code-inner js-file-line">        } <span class="pl-k">else</span> {</td>
        </tr>
        <tr>
          <td id="file-server-java-L57" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="57"></td>
          <td id="file-server-java-LC57" class="blob-code blob-code-inner js-file-line">            <span class="pl-c"><span class="pl-c">//</span> 404</span></td>
        </tr>
        <tr>
          <td id="file-server-java-L58" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="58"></td>
          <td id="file-server-java-LC58" class="blob-code blob-code-inner js-file-line">            <span class="pl-k">byte</span>[] notFoundContent <span class="pl-k">=</span> <span class="pl-s"><span class="pl-pds">"</span>&lt;h1&gt;Not found :(&lt;/h1&gt;<span class="pl-pds">"</span></span><span class="pl-k">.</span>getBytes();</td>
        </tr>
        <tr>
          <td id="file-server-java-L59" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="59"></td>
          <td id="file-server-java-LC59" class="blob-code blob-code-inner js-file-line">            sendResponse(client, <span class="pl-s"><span class="pl-pds">"</span>404 Not Found<span class="pl-pds">"</span></span>, <span class="pl-s"><span class="pl-pds">"</span>text/html<span class="pl-pds">"</span></span>, notFoundContent);</td>
        </tr>
        <tr>
          <td id="file-server-java-L60" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="60"></td>
          <td id="file-server-java-LC60" class="blob-code blob-code-inner js-file-line">        }</td>
        </tr>
        <tr>
          <td id="file-server-java-L61" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="61"></td>
          <td id="file-server-java-LC61" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L62" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="62"></td>
          <td id="file-server-java-LC62" class="blob-code blob-code-inner js-file-line">    }</td>
        </tr>
        <tr>
          <td id="file-server-java-L63" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="63"></td>
          <td id="file-server-java-LC63" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L64" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="64"></td>
          <td id="file-server-java-LC64" class="blob-code blob-code-inner js-file-line">    <span class="pl-k">private</span> <span class="pl-k">static</span> <span class="pl-k">void</span> <span class="pl-en">sendResponse</span>(<span class="pl-smi">Socket</span> <span class="pl-v">client</span>, <span class="pl-smi">String</span> <span class="pl-v">status</span>, <span class="pl-smi">String</span> <span class="pl-v">contentType</span>, <span class="pl-k">byte</span>[] <span class="pl-v">content</span>) <span class="pl-k">throws</span> <span class="pl-smi">IOException</span> {</td>
        </tr>
        <tr>
          <td id="file-server-java-L65" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="65"></td>
          <td id="file-server-java-LC65" class="blob-code blob-code-inner js-file-line">        <span class="pl-smi">OutputStream</span> clientOutput <span class="pl-k">=</span> client<span class="pl-k">.</span>getOutputStream();</td>
        </tr>
        <tr>
          <td id="file-server-java-L66" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="66"></td>
          <td id="file-server-java-LC66" class="blob-code blob-code-inner js-file-line">        clientOutput<span class="pl-k">.</span>write((<span class="pl-s"><span class="pl-pds">"</span>HTTP/1.1 <span class="pl-cce">\r\n</span><span class="pl-pds">"</span></span> <span class="pl-k">+</span> status)<span class="pl-k">.</span>getBytes());</td>
        </tr>
        <tr>
          <td id="file-server-java-L67" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="67"></td>
          <td id="file-server-java-LC67" class="blob-code blob-code-inner js-file-line">        clientOutput<span class="pl-k">.</span>write((<span class="pl-s"><span class="pl-pds">"</span>ContentType: <span class="pl-pds">"</span></span> <span class="pl-k">+</span> contentType <span class="pl-k">+</span> <span class="pl-s"><span class="pl-pds">"</span><span class="pl-cce">\r\n</span><span class="pl-pds">"</span></span>)<span class="pl-k">.</span>getBytes());</td>
        </tr>
        <tr>
          <td id="file-server-java-L68" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="68"></td>
          <td id="file-server-java-LC68" class="blob-code blob-code-inner js-file-line">        clientOutput<span class="pl-k">.</span>write(<span class="pl-s"><span class="pl-pds">"</span><span class="pl-cce">\r\n</span><span class="pl-pds">"</span></span><span class="pl-k">.</span>getBytes());</td>
        </tr>
        <tr>
          <td id="file-server-java-L69" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="69"></td>
          <td id="file-server-java-LC69" class="blob-code blob-code-inner js-file-line">        clientOutput<span class="pl-k">.</span>write(content);</td>
        </tr>
        <tr>
          <td id="file-server-java-L70" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="70"></td>
          <td id="file-server-java-LC70" class="blob-code blob-code-inner js-file-line">        clientOutput<span class="pl-k">.</span>write(<span class="pl-s"><span class="pl-pds">"</span><span class="pl-cce">\r\n\r\n</span><span class="pl-pds">"</span></span><span class="pl-k">.</span>getBytes());</td>
        </tr>
        <tr>
          <td id="file-server-java-L71" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="71"></td>
          <td id="file-server-java-LC71" class="blob-code blob-code-inner js-file-line">        clientOutput<span class="pl-k">.</span>flush();</td>
        </tr>
        <tr>
          <td id="file-server-java-L72" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="72"></td>
          <td id="file-server-java-LC72" class="blob-code blob-code-inner js-file-line">        client<span class="pl-k">.</span>close();</td>
        </tr>
        <tr>
          <td id="file-server-java-L73" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="73"></td>
          <td id="file-server-java-LC73" class="blob-code blob-code-inner js-file-line">    }</td>
        </tr>
        <tr>
          <td id="file-server-java-L74" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="74"></td>
          <td id="file-server-java-LC74" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L75" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="75"></td>
          <td id="file-server-java-LC75" class="blob-code blob-code-inner js-file-line">    <span class="pl-k">private</span> <span class="pl-k">static</span> <span class="pl-smi">Path</span> <span class="pl-en">getFilePath</span>(<span class="pl-smi">String</span> <span class="pl-v">path</span>) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L76" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="76"></td>
          <td id="file-server-java-LC76" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">if</span> (<span class="pl-s"><span class="pl-pds">"</span>/<span class="pl-pds">"</span></span><span class="pl-k">.</span>equals(path)) {</td>
        </tr>
        <tr>
          <td id="file-server-java-L77" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="77"></td>
          <td id="file-server-java-LC77" class="blob-code blob-code-inner js-file-line">            path <span class="pl-k">=</span> <span class="pl-s"><span class="pl-pds">"</span>/index.html<span class="pl-pds">"</span></span>;</td>
        </tr>
        <tr>
          <td id="file-server-java-L78" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="78"></td>
          <td id="file-server-java-LC78" class="blob-code blob-code-inner js-file-line">        }</td>
        </tr>
        <tr>
          <td id="file-server-java-L79" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="79"></td>
          <td id="file-server-java-LC79" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L80" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="80"></td>
          <td id="file-server-java-LC80" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">return</span> <span class="pl-smi">Paths</span><span class="pl-k">.</span>get(<span class="pl-s"><span class="pl-pds">"</span>/tmp/www<span class="pl-pds">"</span></span>, path);</td>
        </tr>
        <tr>
          <td id="file-server-java-L81" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="81"></td>
          <td id="file-server-java-LC81" class="blob-code blob-code-inner js-file-line">    }</td>
        </tr>
        <tr>
          <td id="file-server-java-L82" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="82"></td>
          <td id="file-server-java-LC82" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L83" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="83"></td>
          <td id="file-server-java-LC83" class="blob-code blob-code-inner js-file-line">    <span class="pl-k">private</span> <span class="pl-k">static</span> <span class="pl-smi">String</span> <span class="pl-en">guessContentType</span>(<span class="pl-smi">Path</span> <span class="pl-v">filePath</span>) <span class="pl-k">throws</span> <span class="pl-smi">IOException</span> {</td>
        </tr>
        <tr>
          <td id="file-server-java-L84" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="84"></td>
          <td id="file-server-java-LC84" class="blob-code blob-code-inner js-file-line">        <span class="pl-k">return</span> <span class="pl-smi">Files</span><span class="pl-k">.</span>probeContentType(filePath);</td>
        </tr>
        <tr>
          <td id="file-server-java-L85" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="85"></td>
          <td id="file-server-java-LC85" class="blob-code blob-code-inner js-file-line">    }</td>
        </tr>
        <tr>
          <td id="file-server-java-L86" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="86"></td>
          <td id="file-server-java-LC86" class="blob-code blob-code-inner js-file-line">
</td>
        </tr>
        <tr>
          <td id="file-server-java-L87" class="blob-num js-line-number js-code-nav-line-number js-blob-rnum" data-line-number="87"></td>
          <td id="file-server-java-LC87" class="blob-code blob-code-inner js-file-line">}</td>
        </tr>
  </tbody></table>
</div>


  </div>

  </div>
</div>

      </div>
      <div class="gist-meta">
        <a href="https://gist.github.com/mateuszjarzyna/780144cb34c342597cdfea2c47369f86/raw/0dea1d571f756c3c1e0a0f7c272cef5b12807e73/Server.java" style="float:right">view raw</a>
        <a href="https://gist.github.com/mateuszjarzyna/780144cb34c342597cdfea2c47369f86#file-server-java">
          Server.java
        </a>
        hosted with ❤ by <a href="https://github.com">GitHub</a>
      </div>
    </div>
</div>

<script id="gist-ltag" src="https://gist.github.com/mateuszjarzyna/780144cb34c342597cdfea2c47369f86.js"></script><link rel="stylesheet" href="https://github.githubassets.com/assets/gist-embed-51d58df8adad.css"></div>




          </div>

        </div>
