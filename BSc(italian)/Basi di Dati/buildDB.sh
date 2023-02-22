echo "Generating PDF for Basi Di Dati"
echo $(pandoc --resource-path=src:src/images src/*.md -o db2.pdf -f markdown-implicit_figures)
