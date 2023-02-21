echo "Generating PDF for Databases 2"
echo $(pandoc --resource-path=src:src/images src/*.md -o db2.pdf -f markdown-implicit_figures)
