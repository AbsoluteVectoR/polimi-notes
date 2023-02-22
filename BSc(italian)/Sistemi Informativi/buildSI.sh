echo "Generating PDF for Sistemi Informativi"
echo $(pandoc --resource-path=src:src/images src/*.md -o si.pdf -f markdown-implicit_figures)
