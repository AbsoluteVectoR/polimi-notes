echo "Generating PDF for Databases 2"
echo $(pandoc --resource-path=src:src/images src/*.md -o databases2.pdf -f markdown-implicit_figures)
