1. outline and outline-offset; (not supported by IE)
```
outline:2px solid red;
outline-offset: 15px;
```
2. CSS3 to draw a circle:
```
border-radius: 50%;
```
3. Circle image and hover shadow: border-radius:50; box-shadow:0 0 2px 1px grey;
```
image{
border-radius:50%;
}
a:hover{
box-shadow: 0 0 2px 1px rgba(0, 140, 186, 0.5);
}
<a><img /></a>

```
4. Responsive image
```
img {
    max-width: 100%;
    height: auto;
}
```
5. Button hover to show :after content >>
```
.button:hover span:after {
  opacity: 1;
  right: 0;
}
```
6. CSS3 media query to add labels:
```
@media screen and (max-width: 1000px) and (min-width: 700px) {
    ul li a:before {
        content: "Email: ";
        font-style: italic;
        color: #666666;
    }
}

@media screen and (max-width: 699px) and (min-width: 520px) {
    ul li a {
        padding-left: 30px;
        background: url(email-icon.png) left center no-repeat;
    }
}

```
