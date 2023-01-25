echo "Generating PDF for Economia e Organizzazione Aziendale"
echo $(pandoc --resource-path=src:src/images src/*.md -o eco.pdf --verbose -f markdown-implicit_figures)
