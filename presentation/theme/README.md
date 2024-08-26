# Factor10 Slidev Theme

A theme for factor10 for [Slidev](https://github.com/slidevjs/slidev).

Based on https://github.com/slidevjs/themes/tree/main/packages/theme-seriph

## Install

Add this repository as a subtree:

```shell
$ git remote add theme git@github.com:factor10/s
$ git subtree -P theme add theme/main
```

Add the following frontmatter to your `slides.md`. Start Slidev then it will prompt you to install the theme automatically.

```yaml
theme: ./theme
```

Learn more about [how to use a theme](https://sli.dev/themes/use).

## Update
Update the subtree (add the _theme_ remote if you haven't already):

```shell
$ git subtree -P theme pull theme main
```

## Customization

```yaml
---
theme: serif
themeConfig:
  primary: '#5d8392'
---

## License

MIT License © 2021 [Anthony Fu](https://github.com/antfu), [factor10](https://factor10.com)
