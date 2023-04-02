echo "Generating PDF for Basi Di Dati"
echo $(pandoc --resource-path=src:src/images src/*.md -o basi_dati.pdf -f markdown-implicit_figures)
