echo "Generating PDF for Computer Graphics"
echo $(pandoc --resource-path=src:src/images src/*.md -o cg.pdf -f markdown-implicit_figures)
