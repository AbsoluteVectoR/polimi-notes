echo "Generating PDF for Hypermedia Applications"
echo $(pandoc --resource-path=src:src/images src/*.md -o hypermediaApps.pdf -f markdown-implicit_figures)
