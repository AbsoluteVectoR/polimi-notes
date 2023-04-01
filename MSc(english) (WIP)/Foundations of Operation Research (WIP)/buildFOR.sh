echo "Generating PDF for Foundations Of Operation Research"
echo $(pandoc --resource-path=src:src/images src/*.md -o for.pdf -f markdown-implicit_figures)
