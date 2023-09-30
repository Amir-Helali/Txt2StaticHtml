# Txt2StaticHtml

Txt2StaticHtml is a command line tool for converting text and markdown files to static HTML files. 

## Setup

- Make sure to have .Net SDK installed and added to the Path in evnrionment variables.
- Clone the repository.
- Navigate to the local project directory by using the command prompt.
- Navigate to the Text2StaticHtml directory where the source code is.
- Build the application by using the command:
```
dotnet build
```
- Change directory to where the executable file was created: `bin/debug/net6.0 (Your .Net version might be different)`
- Run the application using the command:
```
Text2StaticHtml
```

## Options & Usage

- Convert a single file, text files, and markdown files in a directory to html: `By default the ouput directory containing the converted file(s) will be in current directory under the name "til"`
```
Text2StaticHtml <Inputpath>
```
- Display the help menu:
```
Text2StaticHtml
or
Text2StaticHtml -h or --help
```
- Display the name and the version of the app:
```
Text2StaticHtml -v or --version
```
- Add a CSS stylesheet url and apply it to the converted html file(s):
```
Text2StaticHtml -s or --stylesheet <stylesheeturl> <inputpath>
```
- Add a language code and apply it to the converted html files(s):
```
Text2StaticHtml -l or --lang <language code> <inputpath>
```
- Create a custom output directory that already exists (if it doesn't exist, it'll be created): `If <OutputPath> not provided for the custom output directory while using this option, the default "til" directory is used.`
```
Text2StaticHtml -o or --output <inputPath> <OutputPath>
```

## Examples
- Text file:
```
Text2StaticHtml C:\Users\amir\Desktop\Text2StaticHtml\InputDirectory\Example1.txt
```
Example1.html:
```html
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Example1</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="">
</head>
<body>
	<p>
	Lorem ipsum dolor sit amet. Aut eaque Quis aut deserunt ipsa et iste cumque in beatae culpa ut architecto consequatur qui numquam dolorem aut magnam assumenda. Id eligendi laudantium eum atque sint sit cumque possimus eos quaerat sunt non architecto commodi et fugit excepturi ut harum animi? Non rerum tenetur eum quaerat aliquid a explicabo quaerat At rerum dolor ab aliquid itaque.
	</p>
	<p>
	Aut modi quae in nihil voluptatem non architecto nobis et galisum saepe et dolorem voluptate est eligendi molestias. Non beatae eius et vero dicta ut esse impedit rem quis excepturi.
	</p>
	<p>
	Et corrupti laudantium nam voluptates quos in animi culpa et magnam officiis sit delectus error et omnis rerum vel dolorem ipsam? Id eligendi consequatur sit ipsa similique qui excepturi earum est nostrum voluptatum. Et veritatis eligendi et odit magnam aut velit voluptas non molestiae iste hic nisi soluta aut omnis aperiam ut dolores dolor!
	</p>
</body>
</html>
```
- Directory of files: (ignores non-text files)
```
Text2StaticHtml C:\Users\amir\Desktop\Text2StaticHtml\InputDirectory
```
Example1.html:
```html
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Example1</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="">
</head>
<body>
	<p>
	Lorem ipsum dolor sit amet. Aut eaque Quis aut deserunt ipsa et iste cumque in beatae culpa ut architecto consequatur qui numquam dolorem aut magnam assumenda. Id eligendi laudantium eum atque sint sit cumque possimus eos quaerat sunt non architecto commodi et fugit excepturi ut harum animi? Non rerum tenetur eum quaerat aliquid a explicabo quaerat At rerum dolor ab aliquid itaque.
	</p>
	<p>
	Aut modi quae in nihil voluptatem non architecto nobis et galisum saepe et dolorem voluptate est eligendi molestias. Non beatae eius et vero dicta ut esse impedit rem quis excepturi.
	</p>
	<p>
	Et corrupti laudantium nam voluptates quos in animi culpa et magnam officiis sit delectus error et omnis rerum vel dolorem ipsam? Id eligendi consequatur sit ipsa similique qui excepturi earum est nostrum voluptatum. Et veritatis eligendi et odit magnam aut velit voluptas non molestiae iste hic nisi soluta aut omnis aperiam ut dolores dolor!
	</p>
</body>
</html>
```
Example2.html:
```html
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Example2</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="">
</head>
<body>
	<p>
	Lorem ipsum dolor sit amet. Qui ipsam quas eum voluptas quis sed natus rerum. Ut modi consequatur id corporis quisquam vel quia esse non cumque nemo. Eos vero nostrum aut repudiandae molestiae et sint aliquam! Eos cumque praesentium vel sint exercitationem sed magnam autem sit quidem voluptatem et fuga doloremque.
	</p>
	<p>
	Ut cumque enim est voluptate dolor aut explicabo nihil. Est omnis vitae qui molestias magnam eos iure dolorum eos repellendus repellat et magnam optio? Et perferendis quasi ea voluptatem adipisci quo architecto porro! Et ipsum minus et quae consequuntur et similique veritatis et deserunt molestias qui corporis distinctio rem voluptas enim!
	</p>
	<p>
	Sed neque repellendus hic distinctio dolor rem Quis rerum. Sit recusandae accusamus ut laborum ipsam ut aliquid sint. Sed dolor animi vel deserunt velit et galisum molestiae vel labore quaerat id distinctio aliquid.
	</p>
</body>
</html>
```
- Stylesheet:
```
Text2StaticHtml -s https://cdnjs.cloudflare.com/ajax/libs/tufte-css/1.8.0/tufte.min.css C:\Users\amir\Desktop\Text2StaticHtml\InputDirectory\Example1.txt
```
Example1.html (With stylesheet applied):
```html
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Example1</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/tufte-css/1.8.0/tufte.min.css">
</head>
<body>
	<p>
	Lorem ipsum dolor sit amet. Aut eaque Quis aut deserunt ipsa et iste cumque in beatae culpa ut architecto consequatur qui numquam dolorem aut magnam assumenda. Id eligendi laudantium eum atque sint sit cumque possimus eos quaerat sunt non architecto commodi et fugit excepturi ut harum animi? Non rerum tenetur eum quaerat aliquid a explicabo quaerat At rerum dolor ab aliquid itaque.
	</p>
	<p>
	Aut modi quae in nihil voluptatem non architecto nobis et galisum saepe et dolorem voluptate est eligendi molestias. Non beatae eius et vero dicta ut esse impedit rem quis excepturi.
	</p>
	<p>
	Et corrupti laudantium nam voluptates quos in animi culpa et magnam officiis sit delectus error et omnis rerum vel dolorem ipsam? Id eligendi consequatur sit ipsa similique qui excepturi earum est nostrum voluptatum. Et veritatis eligendi et odit magnam aut velit voluptas non molestiae iste hic nisi soluta aut omnis aperiam ut dolores dolor!
	</p>
</body>
</html>
```
```
Text2StaticHtml Example2.md
```
Example4.md
```md 
# Lorem ipsum dolor sit amet. Qui ipsam quas eum voluptas quis sed natus rerum. Ut modi consequatur id corporis quisquam vel quia esse non cumque nemo. Eos vero nostrum aut repudiandae molestiae et sint aliquam! Eos cumque praesentium vel sint exercitationem sed magnam autem sit quidem voluptatem et fuga doloremque.



## Ut cumque enim est voluptate dolor aut explicabo nihil. Est omnis vitae qui molestias magnam eos iure dolorum eos repellendus repellat et magnam optio? Et perferendis quasi ea voluptatem adipisci quo architecto porro! Et ipsum minus et quae consequuntur et similique veritatis et deserunt molestias qui corporis distinctio rem voluptas enim!



[link](link)

Sed neque repellendus hic distinctio dolor rem Quis rerum. Sit recusandae accusamus ut laborum ipsam ut aliquid sint. Sed dolor animi vel deserunt velit et galisum molestiae vel labore quaerat id distinctio aliquid.
```
Example4.html
```html
<!doctype html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<title>Example2.md</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<link rel="stylesheet" href="">
</head>
<body>
	<h1>
	 Lorem ipsum dolor sit amet. Qui ipsam quas eum voluptas quis sed natus rerum. Ut modi consequatur id corporis quisquam vel quia esse non cumque nemo. Eos vero nostrum aut repudiandae molestiae et sint aliquam! Eos cumque praesentium vel sint exercitationem sed magnam autem sit quidem voluptatem et fuga doloremque.
	</h1>
	<h2>
	 Ut cumque enim est voluptate dolor aut explicabo nihil. Est omnis vitae qui molestias magnam eos iure dolorum eos repellendus repellat et magnam optio? Et perferendis quasi ea voluptatem adipisci quo architecto porro! Et ipsum minus et quae consequuntur et similique veritatis et deserunt molestias qui corporis distinctio rem voluptas enim!
	</h2>
	<a href=link>
	link
	</a>
	<p>
	Sed neque repellendus hic distinctio dolor rem Quis rerum. Sit recusandae accusamus ut laborum ipsam ut aliquid sint. Sed dolor animi vel deserunt velit et galisum molestiae vel labore quaerat id distinctio aliquid.
	</p>
</body>
</html>
```
