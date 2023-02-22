echo "Generating PDF for Meccanica"
echo $(pandoc --resource-path=src:src/images src/*.md -o meccanica.pdf -f markdown-implicit_figures)
