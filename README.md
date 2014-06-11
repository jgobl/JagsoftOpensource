JagsoftOpensource
=================

Open Source Software


A collection of bits and bobs to help make development easier.

HtmlHelpers
- ActionLinkHelpers
  - BootstrapHighlightedActionLink : A html helper for use with bootsrap to   highlight a navigation link as active when the user is currently on that existing page. Has the same signature as one of the out of the box ActionLink helpers with an additional string property of the class to add to signify the link is active.

Example usage

```html

<div class="blog-masthead">
        <div class="container">
            <nav class="blog-nav">
                @Html.BootstrapHighlightedActionLink("Home", "Index", "Home", null, new Dictionary<string, object> { { "class", "blog-nav-item" } }, "active")
                @Html.BootstrapHighlightedActionLink("About", "About", "Home", null, new Dictionary<string, object> { { "class", "blog-nav-item" } }, "active")
                @Html.BootstrapHighlightedActionLink("Contact", "Create", "Contact", null, new Dictionary<string, object> { { "class", "blog-nav-item" } }, "active")
            </nav>
        </div>
    </div>
  
```
