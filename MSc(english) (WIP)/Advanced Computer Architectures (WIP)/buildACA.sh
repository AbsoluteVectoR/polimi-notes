echo "Generating PDF for Advanced Computer Infrastructures"
echo $(pandoc --resource-path=src:src/images src/*.md -o aca.pdf -f markdown-implicit_figures)
