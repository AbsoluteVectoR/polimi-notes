echo "Generating PDF for Ingegneria del Software"
echo $(pandoc --resource-path=src:src/images src/*.md -o sw.pdf -f markdown-implicit_figures)
